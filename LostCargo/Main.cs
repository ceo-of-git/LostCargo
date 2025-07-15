using System;
using System.Numerics;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using LostCargo;
using LostCargo.Items;
using R2API;
using RoR2;
using RoR2.Orbs;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using Vector3 = UnityEngine.Vector3;

namespace LostCargo
{
    [BepInDependency(ItemAPI.PluginGUID)]
    [BepInDependency(LanguageAPI.PluginGUID)]
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]

    public class Main : BaseUnityPlugin
    {

        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "ceo_of_PetrichorV";
        public const string PluginName = "LostCargo";
        public const string PluginVersion = "1.0.0";
        public static AssetBundle bundle;

        public static ProcType lithiumIonProcType;

        public void Awake()
        {
            // Init Log.cs
            Log.Init(Logger);
            
            GlobalEventManager.onCharacterDeathGlobal += OnCharacterDeathGlobal;                        // Events: On Enemy Death
            On.RoR2.EquipmentSlot.PerformEquipmentAction += PerformEquipmentAction;                     // Events: On Equipment Use
            On.RoR2.HealthComponent.TakeDamageProcess += TakeDamageProcess;                             // Events: On Take Damage Process
            On.RoR2.GlobalEventManager.ProcessHitEnemy += OnEnemyHit;                                   // Events: On Enemy Hit
            On.RoR2.HealthComponent.Heal += OnHeal;                                                     // Events: On Heal
            On.RoR2.CharacterBody.RecalculateStats += OnRecalculateStats;                               // Events: Recalculate Stats
            On.RoR2.Run.BeginStage += OnStageBegin;                                                     // Events: On New Stage


            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LostCargo.lostcargo_assets")) {
                bundle = AssetBundle.LoadFromStream(stream);
            }

            // Init our Items
            // --- Items will be Initialized in these other files but their function will be coded here.
            // --- This is because I don't like files with 10,000 lines.
            Common.Init();
            Uncommon.Init();
            Legendary.Init();
            Lunar.Init();
            Equipment.Init();

            // Init our custom Proc Types
            // Starting at 7,500 here in the hopes that it does not overlap with any other mod (lol)
            lithiumIonProcType = (ProcType)7500;

        }

        private void OnEnemyHit(On.RoR2.GlobalEventManager.orig_ProcessHitEnemy orig, GlobalEventManager self, DamageInfo damageInfo, GameObject victim)
        {
            orig(self, damageInfo, victim);

            CharacterBody attackerBody = damageInfo.attacker.GetComponent<CharacterBody>();
            CharacterBody victimBody = victim ? victim.GetComponent<CharacterBody>() : null;

            var inventory = attackerBody?.inventory;
            var master = attackerBody?.master;


            if (inventory)
            {
                // Lithium Ion Battery (5% Chance to strike enemy for increasing amounts of damage)
                int itemCountLithiumIon = inventory.GetItemCount(Uncommon.lithiumIonDef.itemIndex);
                if (itemCountLithiumIon > 0)
                {
                    if (Util.CheckRoll(2f + (3f * itemCountLithiumIon) * damageInfo.procCoefficient, master) && !damageInfo.procChainMask.HasProc(lithiumIonProcType))
                    {
                        float lithiumIonDamage = attackerBody.damage;
                        ProcChainMask procChainMaskLithium = damageInfo.procChainMask;
                        procChainMaskLithium.AddProc(lithiumIonProcType);
                        HurtBox target = victimBody.mainHurtBox;
                        if (victimBody.hurtBoxGroup)
                        {
                            target = victimBody.hurtBoxGroup.hurtBoxes[UnityEngine.Random.Range(0, victimBody.hurtBoxGroup.hurtBoxes.Length)];
                        }
                        LightningOrb lightningOrb = new LightningOrb
                        {
                            origin = attackerBody.corePosition,
                            damageValue = lithiumIonDamage,
                            isCrit = Util.CheckRoll(attackerBody.crit, master),
                            teamIndex = attackerBody.teamComponent.teamIndex,
                            attacker = attackerBody.gameObject,
                            damageColorIndex = DamageColorIndex.Item,
                            procCoefficient = 2f,
                            procChainMask = procChainMaskLithium,
                            target = target
                        };

                        OrbManager.instance.AddOrb(lightningOrb);
                    }
                }
            }

        }

        private void OnStageBegin(On.RoR2.Run.orig_BeginStage orig, Run self)
        {
            orig(self);

            // Loop through ALL players
            foreach (var player in PlayerCharacterMasterController.instances)
            {
                var body = player.master;
                if (body.inventory && body != null)
                {

                    // Balatro Joker (+4 Levels on stage start)
                    int itemCountJoker = body.inventory.GetItemCount(Legendary.balatroJoker.itemIndex);
                    if (itemCountJoker > 0)
                    {
                        var playerBody = body.GetBody();
                        var fakeLevel = (uint)playerBody.level;

                        for (int i = 0; i < (4 * itemCountJoker); i++)
                        {
                            body.GiveExperience(RoR2.TeamManager.GetExperienceForLevel(fakeLevel));
                            fakeLevel++;
                        }

                        playerBody.RecalculateStats();
                    }
                }
            }
        }

        private void OnCharacterBodyStart(On.RoR2.CharacterBody.orig_Start orig, CharacterBody self)
        {
            if (self.inventory)
            {
                // Balatro Joker (+4 Levels per item per stage)
                int itemCountJoker = self.inventory.GetItemCount(Legendary.balatroJoker.itemIndex);
                if (itemCountJoker > 0)
                {
                    var fakeLevel = (uint)self.level;
                    for (int i = 0; i < (4 * itemCountJoker); i++)
                    {
                        self.master.GiveExperience(RoR2.TeamManager.GetExperienceForLevel(fakeLevel));
                        fakeLevel++;
                    }

                    self.RecalculateStats();
                }
            }

            orig(self);
        }

        private void OnRecalculateStats(On.RoR2.CharacterBody.orig_RecalculateStats orig, CharacterBody self)
        {
            orig(self); // Every Vanilla Item

            if (self.inventory)
            {
                // Magic Top Hat Update (Move faster but deal less damage depending on your hp.)
                int itemCountMagic = self.inventory.GetItemCount(Lunar.magicHat.itemIndex);
                if (itemCountMagic > 0)
                {
                    self.moveSpeed *= 1f + Mathf.Min((itemCountMagic * 0.05f) * (self.healthComponent.fullCombinedHealth / self.healthComponent.health), 5.0f);
                    self.damage *= 1f - Mathf.Min((itemCountMagic * 0.05f) * (self.healthComponent.fullCombinedHealth / self.healthComponent.health), 0.9f);
                }

                // Plastic Knife (+3 Damage, +6 per stack)
                int itemCountKnife = self.inventory.GetItemCount(Common.plasticKnifeDef.itemIndex);
                if (itemCountKnife > 0)
                {
                    self.damage += -3 + (6 * itemCountKnife);
                }
            }
        }

        private float OnHeal(On.RoR2.HealthComponent.orig_Heal orig, HealthComponent self, float amount, ProcChainMask procChainMask, bool nonRegen)
        {
            float result = orig(self, amount, procChainMask, nonRegen);

            if (self.body) { self.body.RecalculateStats(); }  // Recalculate stats after healing (Mainly for Magic Hat Purposes)
            return result;
        }

        private void TakeDamageProcess(On.RoR2.HealthComponent.orig_TakeDamageProcess orig, HealthComponent self, DamageInfo damageInfo)
        {
            orig(self, damageInfo);

            if (self.body) { self.body.RecalculateStats(); } // Recalculate stats after taking damage (Mainly for Magic Hat Purposes)

            // Skip if damage is rejected
            if (damageInfo.rejected)
            {
                return;
            }

            // Adapative Armor (Take less damage if damage taken is BIIIIG...)
            if (damageInfo.damage >= self.fullCombinedHealth * 0.4f)
            {
                var receiverBody = self.body;
                if (receiverBody && receiverBody.inventory)
                {
                    int itemCountAdapative = receiverBody.inventory.GetItemCount(Common.adapativeArmorDef.itemIndex);
                    if (itemCountAdapative > 0)
                    {
                        float totalReduction = 1f - (1f - 0.3f) / (1f + itemCountAdapative * 0.05f);

                        damageInfo.damage *= (1f - totalReduction);
                    }
                }
            }
        }


        private bool PerformEquipmentAction(On.RoR2.EquipmentSlot.orig_PerformEquipmentAction orig, EquipmentSlot self, EquipmentDef equipmentDef)
        {
            // Nuclear Bomb
            if (self.equipmentIndex == Equipment.nuclearBombDef.equipmentIndex)
            {
                Vector3 detonate_pos = self.transform.position;
                float baseDamage = self.characterBody.damage;
                GameObject gameObject_nuke = UnityEngine.Object.Instantiate<GameObject>(GlobalEventManager.CommonAssets.explodeOnDeathPrefab, detonate_pos, UnityEngine.Quaternion.identity);
                DelayBlast component_nuke_blastdelay = gameObject_nuke.GetComponent<DelayBlast>();
                self.characterBody.hasOneShotProtection = false;
                if (component_nuke_blastdelay)
                {
                    component_nuke_blastdelay.position = detonate_pos;
                    component_nuke_blastdelay.baseDamage = Mathf.Infinity;
                    component_nuke_blastdelay.baseForce = 1000000f;
                    component_nuke_blastdelay.bonusForce = Vector3.up * 10000f;
                    component_nuke_blastdelay.radius = Mathf.Infinity;
                    component_nuke_blastdelay.attacker = self.characterBody.gameObject;
                    component_nuke_blastdelay.inflictor = null;
                    component_nuke_blastdelay.crit = Util.CheckRoll(100);
                    component_nuke_blastdelay.maxTimer = 0.0f;
                    component_nuke_blastdelay.damageColorIndex = DamageColorIndex.SuperBleed;
                    component_nuke_blastdelay.falloffModel = BlastAttack.FalloffModel.None;
                }
                TeamFilter component_nuke_teamfilter = gameObject_nuke.GetComponent<TeamFilter>();
                if (component_nuke_teamfilter)
                {
                    component_nuke_teamfilter.teamIndex = TeamIndex.None;
                }

                NetworkServer.Spawn(gameObject_nuke);
                NetworkServer.Spawn(gameObject_nuke);
                NetworkServer.Spawn(gameObject_nuke);

                foreach (var item in FindObjectsOfType<CharacterBody>())
                {
                    item.AddTimedBuff(RoR2Content.Buffs.OnFire, 300, 50);
                    item.AddTimedBuff(RoR2Content.Buffs.Bleeding, 300, 50);
                }

                return true;
            }

            // Cocktail Perithesene
            if (self.equipmentIndex == Equipment.cocktailPeritheseneDef.equipmentIndex)
            {
                self.characterBody.AddTimedBuff(RoR2Content.Buffs.Warbanner, 10f); // Warbanner & War Cry buffs
                self.characterBody.AddTimedBuff(RoR2Content.Buffs.WarCryBuff, 10f);
                return true;
            }

            return orig(self, equipmentDef);
        }

        private void OnCharacterDeathGlobal(DamageReport report)
        {
            // If a character was killed by the world, we shouldn't do anything.
            if (!report.attacker || !report.attackerBody)
            {
                return;
            }

            var attackerCharacterBody = report.attackerBody;

            // We need an inventory to do check for our item
            if (attackerCharacterBody.inventory)
            {
                // Store the amount of our item we have
                //var garbCount = attackerCharacterBody.inventory.GetItemCount(Uncommon.lithiumIonDef.itemIndex);
                //if (garbCount > 0 && Util.CheckRoll(50, attackerCharacterBody.master)) // 50% Chance
                //{
                //    attackerCharacterBody.AddTimedBuff(RoR2Content.Buffs.Cloak, 3 + garbCount);
                //}
            }
        }


        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.F2))
            {
                // Get the player body to use a position:
                var transform = PlayerCharacterMasterController.instances[0].master.GetBodyObject().transform;

                // And then drop our defined item in front of the player.
                Log.Info($"Player pressed F2. Spawning our {Uncommon.lithiumIonDef.name} at coordinates {transform.position}");
                PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex(Uncommon.lithiumIonDef.itemIndex), transform.position, transform.forward * 20f);
            }
        }
    }
}
