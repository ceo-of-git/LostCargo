using BepInEx;
using LostCargo.Items;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LostCargo.Items
{
#pragma warning disable CS0618
    internal class Uncommon
    {
        public static ItemDef lithiumIonDef;

        public static void Init()
        {
            // Initialize items here
            Log.Info("Initializing Uncommon items...");

            InitializeLithiumIonBattery();
        }

        private static void InitializeLithiumIonBattery()
        {
            lithiumIonDef = ScriptableObject.CreateInstance<ItemDef>();

            lithiumIonDef.name = "UNCOMMON_LITHIUMION_NAME";                          // Item Name
            lithiumIonDef.nameToken = "UNCOMMON_LITHIUMION_NAME";                     // ??? just put name here.
            lithiumIonDef.pickupToken = "UNCOMMON_LITHIUMION_PICKUP";                 // Brief pickup description text
            lithiumIonDef.descriptionToken = "UNCOMMON_LITHIUMION_DESC";       // Verbose Description, used in inspections
            lithiumIonDef.loreToken = "UNCOMMON_LITHIUMION_LORE";                  // Logbook Entry Text

            // Tier1=white, Tier2=green, Tier3=red, Lunar=Lunar, Boss=yellow, NoTier=Grayed out
#pragma warning disable Publicizer001
            lithiumIonDef._itemTierDef = Addressables.LoadAssetAsync<ItemTierDef>("RoR2/Base/Common/Tier2Def.asset").WaitForCompletion();
#pragma warning restore Publicizer001

            lithiumIonDef.pickupIconSprite = Main.bundle.LoadAsset<Sprite>("Assets/Textures/Icons/Item/Lithium Ion.png");
            lithiumIonDef.pickupModelPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab");

            lithiumIonDef.canRemove = true;     // If Scrappers or Shrines accept this item
            lithiumIonDef.hidden = false;       // If the player can see it

            // Set up with: https://thunderstore.io/package/KingEnderBrine/ItemDisplayPlacementHelper/
            var displayRules = new ItemDisplayRuleDict();

            // Item Display on Commando
            displayRules.Add("CommandoBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(0.01715F, 0.19126F, 0.24773F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Huntress
            displayRules.Add("HuntressBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(-0.02709F, 0.1288F, 0.11502F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(0.25218F, 0.25218F, 0.25218F)
                }
            });

            // Item Display on Bandit
            displayRules.Add("Bandit2Body", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(-0.02921F, 0.20817F, 0.12235F),
                    localAngles = new Vector3(357.1484F, 357.1935F, 351.1987F),
                    localScale = new Vector3(0.20073F, 0.20073F, 0.20073F)
                }
            });


            // Item Display on MUL-T
            displayRules.Add("ToolbotBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Stomach",
                    localPos = new Vector3(0.11409F, 3.97707F, 1.58197F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(3F, 3F, 3F)
                }
            });

            // Item Display on Engineer
            displayRules.Add("EngiBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(-0.00492F, 0.22847F, 0.17582F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(0.30198F, 0.30198F, 0.30198F)
                }
            });

            // Item Display on Artificer
            displayRules.Add("MageBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(0.0037F, 0.08891F, 0.07071F),
                    localAngles = new Vector3(359.9382F, 5.41181F, 0.17279F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Mercernary
            displayRules.Add("MercBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(0.00848F, 0.12509F, 0.16586F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on REX
            displayRules.Add("TreebotBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Base",
                    localPos = new Vector3(0.01289F, -0.46745F, -0.44732F),
                    localAngles = new Vector3(77.20267F, 196.5424F, 15.23814F),
                    localScale = new Vector3(1F, 1F, 1F)
                }
            });

            // Item Display on Loader
            displayRules.Add("LoaderBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(0.0007F, 0.22442F, -0.28158F),
                    localAngles = new Vector3(347.7752F, 180.2748F, 359.8902F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Acrid
            displayRules.Add("CrocoBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(2.94528F, 0.79341F, 1.25338F),
                    localAngles = new Vector3(349.8013F, 78.38733F, 66.03371F),
                    localScale = new Vector3(2.30711F, 2.30711F, 2.30711F)
                }
            });

            // Item Display on Captain
            displayRules.Add("CaptainBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(0.01191F, 0.18043F, 0.154F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                },
            });

            // Item Display on Heretic
            displayRules.Add("HereticBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(-0.43196F, 0.21143F, 0.10647F),
                    localAngles = new Vector3(289.0966F, 320.0938F, 133.3668F),
                    localScale = new Vector3(0.57001F, 0.57001F, 0.57001F)
                }
            });

            // Item Display on Railgunner
            displayRules.Add("RailgunnerBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Backpack",
                    localPos = new Vector3(-0.0226F, 0.46974F, -0.01177F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Void Fiend
            displayRules.Add("VoidSurvivorBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(-0.00805F, 0.04267F, 0.13072F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Seeker
            displayRules.Add("SeekerBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "UpperArmL",
                    localPos = new Vector3(-0.05001F, 0.18701F, -0.07234F),
                    localAngles = new Vector3(6.14872F, 101.1755F, 266.359F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on False Son
            displayRules.Add("FalseSonBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Stomach",
                    localPos = new Vector3(-0.00142F, -0.09318F, 0.07026F),
                    localAngles = new Vector3(357.3728F, 5.1227F, 357.7204F),
                    localScale = new Vector3(0.35694F, 0.35694F, 0.35694F)
                }
            });

            // Item Display on Chef
            displayRules.Add("ChefBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Lithium Ion.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(-0.03017F, 0.07035F, 0.01274F),
                    localAngles = new Vector3(273.3422F, 146.5554F, 300.6483F),
                    localScale = new Vector3(0.38405F, 0.38405F, 0.38405F)
                }
            });




            ItemAPI.Add(new CustomItem(lithiumIonDef, displayRules));
        }
    }
}
