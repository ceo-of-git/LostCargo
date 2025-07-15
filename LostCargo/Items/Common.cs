using BepInEx;
using LostCargo.Items;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LostCargo.Items
{
#pragma warning disable CS0618
    internal class Common
    {
        public static ItemDef adapativeArmorDef;
        public static ItemDef plasticKnifeDef;
        public static void Init()
        {
            // Initialize items here
            Log.Info("Initializing Common items...");

            InitializeAdaptiveArmor();
            InitializePlasticKnife();
        }

        private static void InitializeAdaptiveArmor()
        {
            adapativeArmorDef = ScriptableObject.CreateInstance<ItemDef>();

            adapativeArmorDef.name = "COMMON_ADAPTIVEARMOR_NAME";
            adapativeArmorDef.nameToken = "COMMON_ADAPTIVEARMOR_NAME";
            adapativeArmorDef.pickupToken = "COMMON_ADAPTIVEARMOR_PICKUP";
            adapativeArmorDef.descriptionToken = "COMMON_ADAPTIVEARMOR_DESC";
            adapativeArmorDef.loreToken = "COMMON_ADAPTIVEARMOR_LORE";

            // Tier1=white, Tier2=green, Tier3=red, Lunar=Lunar, Boss=yellow, NoTier=Grayed out
#pragma warning disable Publicizer001
            adapativeArmorDef._itemTierDef = Addressables.LoadAssetAsync<ItemTierDef>("RoR2/Base/Common/Tier1Def.asset").WaitForCompletion();
#pragma warning restore Publicizer001

            adapativeArmorDef.pickupIconSprite = Main.bundle.LoadAsset<Sprite>("Assets/Textures/Icons/Item/Adapative Armor.png");
            adapativeArmorDef.pickupModelPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab");

            adapativeArmorDef.canRemove = true;     // If Scrappers or Shrines accept this item
            adapativeArmorDef.hidden = false;       // If the player can see it

            // Set up with: https://thunderstore.io/package/KingEnderBrine/ItemDisplayPlacementHelper/
            var displayRules = new ItemDisplayRuleDict();

            // Item Display on Commando
            displayRules.Add("CommandoBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.00008F, 0.03628F, -0.03987F),
                    localAngles = new Vector3(17.45213F, 171.4796F, 357.9546F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Huntress
            displayRules.Add("HuntressBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.00008F, 0.03628F, -0.03987F),
                    localAngles = new Vector3(17.45213F, 171.4796F, 357.9546F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Bandit
            displayRules.Add("Bandit2Body", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.03825F, -0.17413F, -0.0389F),
                    localAngles = new Vector3(10.5297F, 173.0439F, 358.9222F),
                    localScale = new Vector3(0.23648F, 0.23648F, 0.23648F)
                }
            });

            // Item Display on MUL-T
            displayRules.Add("ToolbotBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.00033F, -0.09745F, -0.23879F),
                    localAngles = new Vector3(17.63627F, 171.0404F, 359.2205F),
                    localScale = new Vector3(3.35442F, 3.35442F, 3.35442F)
                }
            });

            // Item Display on Engineer
            displayRules.Add("EngiBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "HeadCenter",
                    localPos = new Vector3(0.00842F, -0.14086F, -0.12041F),
                    localAngles = new Vector3(357.5196F, 171.8495F, 0.75089F),
                    localScale = new Vector3(0.30198F, 0.30198F, 0.30198F)
                }
            });

            // Item Display on Artificer
            displayRules.Add("MageBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.00118F, -0.14948F, -0.09532F),
                    localAngles = new Vector3(17.45213F, 171.4796F, 357.9546F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Mercernary
            displayRules.Add("MercBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.00065F, -0.09487F, -0.03841F),
                    localAngles = new Vector3(17.45213F, 171.4796F, 357.9546F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on REX
            displayRules.Add("TreebotBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Eye",
                    localPos = new Vector3(0.19508F, 0.39601F, 0.19489F),
                    localAngles = new Vector3(81.4361F, 108.3497F, 289.0697F),
                    localScale = new Vector3(0.57627F, 0.57627F, 0.57627F)
                }
            });

            // Item Display on Loader
            displayRules.Add("LoaderBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.00065F, -0.09487F, -0.03841F),
                    localAngles = new Vector3(17.45213F, 171.4796F, 357.9546F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Acrid
            displayRules.Add("CrocoBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.05748F, 1.59476F, -1.43975F),
                    localAngles = new Vector3(7.7855F, 171.822F, 359.4428F),
                    localScale = new Vector3(3.54179F, 3.54179F, 3.54179F)
                }
            });

            // Item Display on Captain
            displayRules.Add("CaptainBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.0124F, -0.0529F, -0.11315F),
                    localAngles = new Vector3(344.9375F, 173.5737F, 358.8669F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Heretic
            displayRules.Add("HereticBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.15918F, 0.1777F, 0.24039F),
                    localAngles = new Vector3(26.9668F, 77.16901F, 285.8569F),
                    localScale = new Vector3(0.41789F, 0.41789F, 0.41789F)
                }
            });

            // Item Display on Railgunner
            displayRules.Add("RailgunnerBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.00045F, -0.09698F, -0.00727F),
                    localAngles = new Vector3(17.45213F, 171.4796F, 357.9546F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Void Fiend
            displayRules.Add("VoidSurvivorBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.00313F, -0.13733F, -0.05062F),
                    localAngles = new Vector3(17.45213F, 171.4796F, 357.9546F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Seeker
            displayRules.Add("SeekerBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.00641F, -0.10994F, -0.04743F),
                    localAngles = new Vector3(20.62307F, 163.8086F, 0.21511F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on False Son
            displayRules.Add("FalseSonBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.0899F, 0.00336F, -0.22505F),
                    localAngles = new Vector3(8.30664F, 170.9225F, 31.26885F),
                    localScale = new Vector3(0.45491F, 0.45491F, 0.45491F)
                }
            });

            // Item Display on Chef
            displayRules.Add("ChefBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Adapative Armor.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.33932F, -0.1121F, 0.00293F),
                    localAngles = new Vector3(81.87589F, 66.05804F, 158.8045F),
                    localScale = new Vector3(0.30891F, 0.30891F, 0.30891F)
                }
            });


            ItemAPI.Add(new CustomItem(adapativeArmorDef, displayRules));
        }

        private static void InitializePlasticKnife()
        {
            plasticKnifeDef = ScriptableObject.CreateInstance<ItemDef>();

            plasticKnifeDef.name = "COMMON_PLASTICKNIFE_NAME";
            plasticKnifeDef.nameToken = "COMMON_PLASTICKNIFE_NAME";
            plasticKnifeDef.pickupToken = "COMMON_PLASTICKNIFE_PICKUP";
            plasticKnifeDef.descriptionToken = "COMMON_PLASTICKNIFE_DESC";
            plasticKnifeDef.loreToken = "COMMON_PLASTICKNIFE_LORE";

            // Tier1=white, Tier2=green, Tier3=red, Lunar=Lunar, Boss=yellow, NoTier=Grayed out
#pragma warning disable Publicizer001
            plasticKnifeDef._itemTierDef = Addressables.LoadAssetAsync<ItemTierDef>("RoR2/Base/Common/Tier1Def.asset").WaitForCompletion();
#pragma warning restore Publicizer001

            plasticKnifeDef.pickupIconSprite = Main.bundle.LoadAsset<Sprite>("Assets/Textures/Icons/Item/Plastic Knife.png");
            plasticKnifeDef.pickupModelPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab");

            plasticKnifeDef.canRemove = true;     // If Scrappers or Shrines accept this item
            plasticKnifeDef.hidden = false;       // If the player can see it

            // Set up with: https://thunderstore.io/package/KingEnderBrine/ItemDisplayPlacementHelper/
            var displayRules = new ItemDisplayRuleDict();

            // Item Display on Commando
            displayRules.Add("CommandoBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "Pelvis",
                    localPos = new Vector3(0.2215F, -0.12977F, 0.07318F),
                    localAngles = new Vector3(348.8876F, 94.05321F, 339.8134F),
                    localScale = new Vector3(0.18088F, 0.18088F, 0.18088F)
                }
            });

            // Item Display on Huntress
            displayRules.Add("HuntressBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(0.08813F, 0.05557F, -0.11365F),
                    localAngles = new Vector3(12.21142F, 170.3353F, 353.1759F),
                    localScale = new Vector3(0.1165F, 0.1165F, 0.1165F)
                }
            });

            // Item Display on Bandit
            displayRules.Add("Bandit2Body", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "Pelvis",
                    localPos = new Vector3(0.14029F, -0.03652F, -0.10818F),
                    localAngles = new Vector3(29.49527F, 146.8124F, 1.5299F),
                    localScale = new Vector3(0.11929F, 0.11929F, 0.11929F)
                }
            });

            // Item Display on MUL-T
            displayRules.Add("ToolbotBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "CalfL",
                    localPos = new Vector3(-0.30868F, -1.37461F, 0.9042F),
                    localAngles = new Vector3(356.6518F, 2.73573F, 2.91595F),
                    localScale = new Vector3(3.35442F, 3.35442F, 3.35442F)
                }
            });

            // Item Display on Engineer
            displayRules.Add("EngiBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "Pelvis",
                    localPos = new Vector3(-0.17944F, -0.04674F, -0.12022F),
                    localAngles = new Vector3(13.24742F, 211.5673F, 356.8815F),
                    localScale = new Vector3(0.14658F, 0.14658F, 0.14658F)
                }
            });

            // Item Display on Artificer
            displayRules.Add("MageBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "Base",
                    localPos = new Vector3(0F, 0F, 0F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(0F, 0F, 0F)
                }
            });

            // Item Display on Mercernary
            displayRules.Add("MercBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "HandL",
                    localPos = new Vector3(0.0708F, 0.15819F, -0.02027F),
                    localAngles = new Vector3(355.7857F, 9.9812F, 106.8554F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on REX
            displayRules.Add("TreebotBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "Base",
                    localPos = new Vector3(0.59175F, 1.70085F, -0.77214F),
                    localAngles = new Vector3(31.24456F, 195.1026F, 217.8001F),
                    localScale = new Vector3(0.57627F, 0.57627F, 0.57627F)
                }
            });

            // Item Display on Loader
            displayRules.Add("LoaderBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(0.04429F, 0.17793F, -0.29696F),
                    localAngles = new Vector3(352.1818F, 171.6666F, 332.6241F),
                    localScale = new Vector3(0.11685F, 0.11685F, 0.11685F)
                }
            });

            // Item Display on Acrid
            displayRules.Add("CrocoBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.05749F, 3.15148F, -0.18057F),
                    localAngles = new Vector3(353.5645F, 180.3837F, 19.45843F),
                    localScale = new Vector3(3.54179F, 3.54179F, 3.54179F)
                }
            });

            // Item Display on Captain
            displayRules.Add("CaptainBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "Pelvis",
                    localPos = new Vector3(0.12299F, -0.15429F, -0.22775F),
                    localAngles = new Vector3(344.9375F, 173.5737F, 358.8669F),
                    localScale = new Vector3(0.1629F, 0.1629F, 0.1629F)
                }
            });

            // Item Display on Heretic
            displayRules.Add("HereticBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.13551F, 0.39368F, 0.0474F),
                    localAngles = new Vector3(332.1025F, 173.0597F, 16.30663F),
                    localScale = new Vector3(0.41789F, 0.41789F, 0.41789F)
                }
            });

            // Item Display on Railgunner
            displayRules.Add("RailgunnerBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "ClavicleL",
                    localPos = new Vector3(-0.0197F, -0.03579F, -0.03745F),
                    localAngles = new Vector3(26.85091F, 161.4483F, 3.99195F),
                    localScale = new Vector3(0.14904F, 0.14904F, 0.14904F)
                }
            });

            // Item Display on Void Fiend
            displayRules.Add("VoidSurvivorBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.43678F, 0.0751F, -0.01477F),
                    localAngles = new Vector3(59.90194F, 205.522F, 307.9799F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Seeker
            displayRules.Add("SeekerBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "Pelvis",
                    localPos = new Vector3(0.16384F, 0.03386F, 0.08223F),
                    localAngles = new Vector3(6.00359F, 203.4687F, 120.3761F),
                    localScale = new Vector3(0.09451F, 0.09451F, 0.09451F)
                }
            });

            // Item Display on False Son
            displayRules.Add("FalseSonBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.72689F, -0.0393F, -0.23033F),
                    localAngles = new Vector3(11.33572F, 194.6261F, 293.8502F),
                    localScale = new Vector3(0.45491F, 0.45491F, 0.45491F)
                }
            });

            // Item Display on Chef
            displayRules.Add("ChefBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Plastic Knife.prefab"),
                    childName = "Chest",
                    localPos = new Vector3(-0.44021F, -0.28273F, 0.23598F),
                    localAngles = new Vector3(84.06331F, 8.47248F, 262.6658F),
                    localScale = new Vector3(0.30891F, 0.30891F, 0.30891F)
                }
            });


            ItemAPI.Add(new CustomItem(plasticKnifeDef, displayRules));
        }
    }
}
