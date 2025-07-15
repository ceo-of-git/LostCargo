using BepInEx;
using LostCargo.Items;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LostCargo.Items
{
    internal class Lunar
    {
        public static ItemDef magicHat;

        public static void Init()
        {
            // Initialize items here
            Log.Info("Initializing Lunar items...");

            InitializeMagicHat();
        }

        private static void InitializeMagicHat()
        {
            magicHat = ScriptableObject.CreateInstance<ItemDef>();

            magicHat.name = "LUNAR_MAGICHAT_NAME";                          // Item Name
            magicHat.nameToken = "LUNAR_MAGICHAT_NAME";                     // ??? just put name here.
            magicHat.pickupToken = "LUNAR_MAGICHAT_PICKUP";                 // Brief pickup description text
            magicHat.descriptionToken = "LUNAR_MAGICHAT_DESC";       // Verbose Description, used in inspections
            magicHat.loreToken = "LUNAR_MAGICHAT_LORE";                  // Logbook Entry Text

            // Tier1=white, Tier2=green, Tier3=red, Lunar=Lunar, Boss=yellow, NoTier=Grayed out
#pragma warning disable Publicizer001
            magicHat._itemTierDef = Addressables.LoadAssetAsync<ItemTierDef>("RoR2/Base/Common/LunarTierDef.asset").WaitForCompletion();
#pragma warning restore Publicizer001

            magicHat.pickupIconSprite = Main.bundle.LoadAsset<Sprite>("Assets/Textures/Icons/Item/Magic Top Hat.png");
            magicHat.pickupModelPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab");

            magicHat.canRemove = true;     // If Scrappers or Shrines accept this item
            magicHat.hidden = false;       // If the player can see it

            // Set up with: https://thunderstore.io/package/KingEnderBrine/ItemDisplayPlacementHelper/
            var displayRules = new ItemDisplayRuleDict();

            // Item Display on Commando
            displayRules.Add("CommandoBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.00096F, 0.31857F, -0.03263F),
                    localAngles = new Vector3(26.14605F, 159.9736F, 353.8564F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Huntress
            displayRules.Add("HuntressBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.02006F, 0.21789F, -0.09231F),
                    localAngles = new Vector3(31.63141F, 134.1785F, 345.1736F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Bandit
            displayRules.Add("Bandit2Body", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.02775F, 0.17779F, 0.04542F),
                    localAngles = new Vector3(20.903F, 141.6877F, 355.928F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });


            // Item Display on MUL-T
            displayRules.Add("ToolbotBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.15886F, 3.09787F, 1.59077F),
                    localAngles = new Vector3(318.5931F, 169.7267F, 21.04252F),
                    localScale = new Vector3(0.67659F, 0.67659F, 0.67659F)
                }
            });

            // Item Display on Engineer
            displayRules.Add("EngiBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "MuzzleRight",
                    localPos = new Vector3(-0.07779F, -0.16563F, -0.23401F),
                    localAngles = new Vector3(340.2983F, 268.4456F, 160.8234F),
                    localScale = new Vector3(0.30198F, 0.30198F, 0.30198F)
                }
            });

            // Item Display on Artificer
            displayRules.Add("MageBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.00012F, 0.10532F, -0.09319F),
                    localAngles = new Vector3(17.45213F, 171.4796F, 357.9546F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Mercernary
            displayRules.Add("MercBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.03812F, 0.17749F, 0.01202F),
                    localAngles = new Vector3(17.45213F, 171.4796F, 357.9546F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on REX
            displayRules.Add("TreebotBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "WeaponPlatform",
                    localPos = new Vector3(0.03658F, -0.33786F, 0.61256F),
                    localAngles = new Vector3(288.5333F, 55.85328F, 118.8578F),
                    localScale = new Vector3(0.25108F, 0.25108F, 0.25108F)
                }
            });

            // Item Display on Loader
            displayRules.Add("LoaderBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.00089F, 0.19847F, -0.03972F),
                    localAngles = new Vector3(17.45213F, 171.4796F, 357.9546F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Acrid
            displayRules.Add("CrocoBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.09609F, -0.17029F, 0.62651F),
                    localAngles = new Vector3(291.5111F, 22.97794F, 159.0592F),
                    localScale = new Vector3(3.54179F, 3.54179F, 3.54179F)
                }
            });

            // Item Display on Captain
            displayRules.Add("CaptainBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.01721F, 0.16492F, 0.05794F),
                    localAngles = new Vector3(15.44183F, 171.7073F, 358.0214F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                },
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.0334F, 0.41647F, 0.0727F),
                    localAngles = new Vector3(15.46724F, 176.6527F, 12.85727F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                },
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.04931F, 0.65443F, 0.08681F),
                    localAngles = new Vector3(14.685F, 168.2976F, 347.5526F),
                    localScale = new Vector3(0.20653F, 0.20653F, 0.20653F)
                }
            });

            // Item Display on Heretic
            displayRules.Add("HereticBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.35661F, -0.12985F, 0.05972F),
                    localAngles = new Vector3(69.62605F, 180.3905F, 262.675F),
                    localScale = new Vector3(0.81558F, 0.81558F, 0.81558F)
                }
            });

            // Item Display on Railgunner
            displayRules.Add("RailgunnerBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.00017F, 0.12818F, -0.06235F),
                    localAngles = new Vector3(17.45213F, 171.4796F, 357.9546F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Void Fiend
            displayRules.Add("VoidSurvivorBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.06657F, 0.15046F, 0.03496F),
                    localAngles = new Vector3(34.00481F, 162.0417F, 355.2139F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Seeker
            displayRules.Add("SeekerBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.00316F, 0.13155F, -0.0404F),
                    localAngles = new Vector3(34.00482F, 162.0417F, 355.2139F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on False Son
            displayRules.Add("FalseSonBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(0.17535F, 0.61408F, -0.02853F),
                    localAngles = new Vector3(27.82013F, 171.8834F, 27.93278F),
                    localScale = new Vector3(0.28185F, 0.28185F, 0.28185F)
                }
            });

            // Item Display on Chef
            displayRules.Add("ChefBody", new[]
            {
                new ItemDisplayRule
                {
                    followerPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Magic Top Hat.prefab"),
                    childName = "Head",
                    localPos = new Vector3(-0.20759F, 0.16169F, -0.31992F),
                    localAngles = new Vector3(339.9846F, 156.066F, 261.1587F),
                    localScale = new Vector3(0.10087F, 0.10087F, 0.10087F)
                }
            });




            ItemAPI.Add(new CustomItem(magicHat, displayRules));
        }
    }
}
