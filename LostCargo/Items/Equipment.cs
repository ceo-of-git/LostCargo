using BepInEx;
using EntityStates;
using LostCargo.Items;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LostCargo.Items
{
#pragma warning disable CS0618
    internal class Equipment
    {
        public static EquipmentDef nuclearBombDef;
        public static EquipmentDef cocktailPeritheseneDef;


        public static void Init()
        {
            // Initialize items here
            Log.Info("Initializing Equipment...");

            LegalizeNuclearBombs();
            InitializeCocktail();
        }

        private static void LegalizeNuclearBombs()
        {
            nuclearBombDef = ScriptableObject.CreateInstance<EquipmentDef>();

            nuclearBombDef.name = "EQUIPMENT_NUCLEARBOMB_NAME";                         // Item Name (no spaces)
            nuclearBombDef.nameToken = "EQUIPMENT_NUCLEARBOMB_NAME";                    // ??? idk just copy the name here aswell.
            nuclearBombDef.pickupToken = "EQUIPMENT_NUCLEARBOMB_PICKUP";                // Brief pickup description text
            nuclearBombDef.descriptionToken = "EQUIPMENT_NUCLEARBOMB_DESC";             // Verbose Description, used in inspections
            nuclearBombDef.loreToken = "EQUIPMENT_NUCLEARBOMB_LORE";                    // Logbook Entry Text

            nuclearBombDef.pickupIconSprite = Main.bundle.LoadAsset<Sprite>("Assets/Textures/Icons/Equipment/Nuclear Bomb.png");
            nuclearBombDef.pickupModelPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab");

            nuclearBombDef.isLunar = false;                 // If this Equipment is Lunar
            nuclearBombDef.enigmaCompatible = true;         // if this Equipment is Enigma Artifact Compatible
            nuclearBombDef.cooldown = 300f;                 // Equipment Cooldown
            nuclearBombDef.isBoss = false;                  // Whether it can drop from bosses
            nuclearBombDef.canDrop = true;                  // Whether it can appear in Equipment Barrels or whatever naturally

            // Set up with: https://thunderstore.io/package/KingEnderBrine/ItemDisplayPlacementHelper/
            var displayRules = new ItemDisplayRuleDict();

            // Item Display on Commando
            displayRules.Add("CommandoBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(0.26102F, 0.50398F, -0.32436F),
                    localAngles = new Vector3(301.0074F, 71.60896F, 113.1095F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Huntress
            displayRules.Add("HuntressBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(0.3535F, 0.22238F, -0.13252F),
                    localAngles = new Vector3(306.782F, 54.29462F, 68.29018F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Bandit
            displayRules.Add("Bandit2Body", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(0.42941F, 0.19987F, -0.15572F),
                    localAngles = new Vector3(290.094F, 54.32014F, 11.04427F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });


            // Item Display on MUL-T
            displayRules.Add("ToolbotBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(1.58059F, 3.09222F, -0.837F),
                    localAngles = new Vector3(2.32293F, 79.50591F, 21.62212F),
                    localScale = new Vector3(1.0619F, 1.0619F, 1.0619F)
                }
            });

            // Item Display on Engineer
            displayRules.Add("EngiBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(-0.07593F, 0.3592F, -0.51801F),
                    localAngles = new Vector3(275.2044F, 330.4841F, 129.6588F),
                    localScale = new Vector3(0.30198F, 0.30198F, 0.30198F)
                }
            });

            // Item Display on Artificer
            displayRules.Add("MageBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(-0.06739F, 0.30546F, -0.3548F),
                    localAngles = new Vector3(296.4514F, 338.5619F, 30.90925F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Mercernary
            displayRules.Add("MercBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Stomach",
                    localPos = new Vector3(-0.03469F, 0.37155F, -0.30095F),
                    localAngles = new Vector3(279.5133F, 4.1486F, 355.7846F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on REX
            displayRules.Add("TreebotBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Base",
                    localPos = new Vector3(0.03658F, 0.25184F, -3.2852F),
                    localAngles = new Vector3(0.00001F, 180F, 180F),
                    localScale = new Vector3(0.62793F, 0.62793F, 0.62793F)
                }
            });

            // Item Display on Loader
            displayRules.Add("LoaderBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(0.24319F, 0.38579F, -0.38319F),
                    localAngles = new Vector3(315.4033F, 68.25347F, 289.7483F),
                    localScale = new Vector3(0.26515F, 0.26515F, 0.26515F)
                }
            });

            // Item Display on Acrid
            displayRules.Add("CrocoBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Base",
                    localPos = new Vector3(-0.09609F, -0.36733F, 7.24225F),
                    localAngles = new Vector3(53.34392F, 0.00001F, 0F),
                    localScale = new Vector3(3.54179F, 3.54179F, 3.54179F)
                }
            });

            // Item Display on Captain
            displayRules.Add("CaptainBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(-0.31877F, -0.13524F, -0.37904F),
                    localAngles = new Vector3(54.70774F, 273.0569F, 230.0618F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                },
            });

            // Item Display on Heretic
            displayRules.Add("HereticBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(-0.06433F, -0.30563F, 0.60944F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(0.68257F, 0.68257F, 0.68257F)
                }
            });

            // Item Display on Railgunner
            displayRules.Add("RailgunnerBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Backpack",
                    localPos = new Vector3(0.19284F, 0.17122F, -0.06471F),
                    localAngles = new Vector3(270.7952F, 89.98524F, 271.9658F),
                    localScale = new Vector3(0.14853F, 0.14853F, 0.14853F)
                }
            });

            // Item Display on Void Fiend
            displayRules.Add("VoidSurvivorBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "ForeArmR",
                    localPos = new Vector3(0.00788F, -0.15775F, -0.0757F),
                    localAngles = new Vector3(80.14194F, 236.1866F, 227.1717F),
                    localScale = new Vector3(0.27447F, 0.27447F, 0.27447F)
                }
            });

            // Item Display on Seeker
            displayRules.Add("SeekerBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Pack",
                    localPos = new Vector3(-0.11926F, 0.07624F, -0.2863F),
                    localAngles = new Vector3(305.7792F, 246.2374F, 110.4169F),
                    localScale = new Vector3(0.26844F, 0.26844F, 0.26844F)
                }
            });

            // Item Display on False Son
            displayRules.Add("FalseSonBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Stomach",
                    localPos = new Vector3(-0.21088F, 0.62354F, -0.35748F),
                    localAngles = new Vector3(306.1858F, 278.3443F, 111.1852F),
                    localScale = new Vector3(0.32576F, 0.32576F, 0.32576F)
                }
            });

            // Item Display on Chef
            displayRules.Add("ChefBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Nuclear Bomb.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(-0.22642F, -0.31711F, -0.17741F),
                    localAngles = new Vector3(355.7209F, 289.9921F, 311.8955F),
                    localScale = new Vector3(0.17351F, 0.17351F, 0.17351F)
                }
            });

            ItemAPI.Add(new CustomEquipment(nuclearBombDef, displayRules));
        }

        private static void InitializeCocktail()
        {
            cocktailPeritheseneDef = ScriptableObject.CreateInstance<EquipmentDef>();

            cocktailPeritheseneDef.name = "EQUIPMENT_PERITHESENE_NAME";                         // Item Name (no spaces)
            cocktailPeritheseneDef.nameToken = "EQUIPMENT_PERITHESENE_NAME";                    // ??? idk just copy the name here aswell.
            cocktailPeritheseneDef.pickupToken = "EQUIPMENT_PERITHESENE_PICKUP";                // Brief pickup description text
            cocktailPeritheseneDef.descriptionToken = "EQUIPMENT_PERITHESENE_DESC";             // Verbose Description, used in inspections
            cocktailPeritheseneDef.loreToken = "EQUIPMENT_PERITHESENE_LORE";                    // Logbook Entry Text

            cocktailPeritheseneDef.pickupIconSprite = Main.bundle.LoadAsset<Sprite>("Assets/Textures/Icons/Equipment/Perithesene.png");
            cocktailPeritheseneDef.pickupModelPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab");

            cocktailPeritheseneDef.isLunar = false;                 // If this Equipment is Lunar
            cocktailPeritheseneDef.enigmaCompatible = true;         // if this Equipment is Enigma Artifact Compatible
            cocktailPeritheseneDef.cooldown = 40f;                 // Equipment Cooldown
            cocktailPeritheseneDef.isBoss = false;                  // Whether it can drop from bosses
            cocktailPeritheseneDef.canDrop = true;                  // Whether it can appear in Equipment Barrels or whatever naturally

            // Set up with: https://thunderstore.io/package/KingEnderBrine/ItemDisplayPlacementHelper/
            var displayRules = new ItemDisplayRuleDict();

            // Item Display on Commando
            displayRules.Add("CommandoBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "Pelvis",
                    localPos = new Vector3(0.16249F, -0.00333F, -0.09772F),
                    localAngles = new Vector3(342.0678F, 0.00004F, 156.086F),
                    localScale = new Vector3(0.02F, 0.02F, 0.02F)
                }
            });

            // Item Display on Huntress
            displayRules.Add("HuntressBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "Stomach",
                    localPos = new Vector3(0.08844F, -0.04149F, 0.12227F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(0.02F, 0.02F, 0.02F)
                }
            });

            // Item Display on Bandit
            displayRules.Add("Bandit2Body", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "Pelvis",
                    localPos = new Vector3(0.16722F, -0.09976F, -0.06771F),
                    localAngles = new Vector3(357.481F, 3.02021F, 328.3251F),
                    localScale = new Vector3(0.02F, 0.02F, 0.02F)
                }
            });


            // Item Display on MUL-T
            displayRules.Add("ToolbotBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "HeadCenter",
                    localPos = new Vector3(0.16468F, 0.69635F, -0.75655F),
                    localAngles = new Vector3(331.0252F, 5.63633F, 324.1677F),
                    localScale = new Vector3(0.30903F, 0.30903F, 0.30903F)
                }
            });

            // Item Display on Engineer
            displayRules.Add("EngiBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(-0.07364F, 0.25606F, 0.21807F),
                    localAngles = new Vector3(342.9776F, 260.9167F, 270.5045F),
                    localScale = new Vector3(0.03036F, 0.03036F, 0.03036F)
                }
            });

            // Item Display on Artificer
            displayRules.Add("MageBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "MuzzleRight",
                    localPos = new Vector3(-0.01428F, 0.02201F, -0.41598F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(0.02F, 0.02F, 0.02F)
                }
            });

            // Item Display on Mercernary
            displayRules.Add("MercBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(0.24107F, 0.22639F, -0.05472F),
                    localAngles = new Vector3(3.46075F, 239.7792F, 1.08797F),
                    localScale = new Vector3(0.03995F, 0.03995F, 0.03995F)
                }
            });

            // Item Display on REX
            displayRules.Add("TreebotBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "Base",
                    localPos = new Vector3(-0.70167F, 0.25184F, -1.21972F),
                    localAngles = new Vector3(317.4221F, 274.174F, 98.66987F),
                    localScale = new Vector3(0.21781F, 0.21781F, 0.21781F)
                }
            });

            // Item Display on Loader
            displayRules.Add("LoaderBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(-0.26336F, -0.0576F, 0.06546F),
                    localAngles = new Vector3(18.88285F, 33.24387F, 333.0354F),
                    localScale = new Vector3(0.02F, 0.02F, 0.02F)
                }
            });

            // Item Display on Acrid
            displayRules.Add("CrocoBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "UpperArmL",
                    localPos = new Vector3(-1.07649F, 0.60336F, -0.54356F),
                    localAngles = new Vector3(51.98138F, 40.48973F, 108.2659F),
                    localScale = new Vector3(0.82929F, 0.82929F, 0.82929F)
                }
            });

            // Item Display on Captain
            displayRules.Add("CaptainBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "Pelvis",
                    localPos = new Vector3(-0.20934F, -0.04724F, -0.09153F),
                    localAngles = new Vector3(354.8946F, 216.8441F, 151.641F),
                    localScale = new Vector3(0.02F, 0.02F, 0.02F)
                },
            });

            // Item Display on Heretic
            displayRules.Add("HereticBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.04823F, 0.36734F, 0.19298F),
                    localAngles = new Vector3(318.8776F, 117.8762F, 353.5938F),
                    localScale = new Vector3(0.02653F, 0.02653F, 0.02653F)
                }
            });

            // Item Display on Railgunner
            displayRules.Add("RailgunnerBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "Backpack",
                    localPos = new Vector3(0.19114F, -0.21043F, -0.13517F),
                    localAngles = new Vector3(9.75519F, 8.87211F, 341.0682F),
                    localScale = new Vector3(0.04838F, 0.04838F, 0.04838F)
                }
            });

            // Item Display on Void Fiend
            displayRules.Add("VoidSurvivorBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "ForeArmR",
                    localPos = new Vector3(0.05747F, -0.22009F, -0.15684F),
                    localAngles = new Vector3(22.55961F, 187.9046F, 176.7803F),
                    localScale = new Vector3(0.02F, 0.02F, 0.02F)
                }
            });

            // Item Display on Seeker
            displayRules.Add("SeekerBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "Pelvis",
                    localPos = new Vector3(-0.19618F, -0.04551F, 0.11257F),
                    localAngles = new Vector3(323.2619F, 319.9768F, 345.531F),
                    localScale = new Vector3(0.02F, 0.02F, 0.02F)
                }
            });

            // Item Display on False Son
            displayRules.Add("FalseSonBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.10243F, 0.23393F, 0.14669F),
                    localAngles = new Vector3(326.7125F, 139.01F, 4.77756F),
                    localScale = new Vector3(0.02F, 0.02F, 0.02F)
                }
            });

            // Item Display on Chef
            displayRules.Add("ChefBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Equipment/Perithesene.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(-0.40225F, -0.42453F, 0.17439F),
                    localAngles = new Vector3(22.98397F, 198.1766F, 70.83453F),
                    localScale = new Vector3(0.07405F, 0.07405F, 0.07405F)
                }
            });

            ItemAPI.Add(new CustomEquipment(cocktailPeritheseneDef, displayRules));
        }
    }

}
