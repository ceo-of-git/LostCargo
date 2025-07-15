using BepInEx;
using LostCargo.Items;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LostCargo.Items
{
    internal class Legendary
    {
        public static ItemDef balatroJoker;
        public static void Init()
        {
            // Initialize items here
            Log.Info("Initializing Legendary items...");

            InitializeBalatroBalatrez();
        }

        private static void InitializeBalatroBalatrez()
        {
            balatroJoker = ScriptableObject.CreateInstance<ItemDef>();

            balatroJoker.name = "LEGENDARY_BALATRO_NAME";                          // Item Name
            balatroJoker.nameToken = "LEGENDARY_BALATRO_NAME";                     // ??? just put name here.
            balatroJoker.pickupToken = "LEGENDARY_BALATRO_PICKUP";                 // Brief pickup description text
            balatroJoker.descriptionToken = "LEGENDARY_BALATRO_DESC";       // Verbose Description, used in inspections
            balatroJoker.loreToken = "LEGENDARY_BALATRO_LORE";                  // Logbook Entry Text

            // Tier1=white, Tier2=green, Tier3=red, Lunar=Lunar, Boss=yellow, NoTier=Grayed out
#pragma warning disable Publicizer001
            balatroJoker._itemTierDef = Addressables.LoadAssetAsync<ItemTierDef>("RoR2/Base/Common/Tier3Def.asset").WaitForCompletion();
#pragma warning restore Publicizer001

            balatroJoker.pickupIconSprite = Main.bundle.LoadAsset<Sprite>("Assets/Textures/Icons/Item/Joker.png");
            balatroJoker.pickupModelPrefab = Main.bundle.LoadAsset<GameObject>("Assets/Models/Prefabs/Item/Joker.prefab");

            balatroJoker.canRemove = true;     // If Scrappers or Shrines accept this item
            balatroJoker.hidden = false;       // If the player can see it

            // Set up with: https://thunderstore.io/package/KingEnderBrine/ItemDisplayPlacementHelper/
            var displayRules = new ItemDisplayRuleDict(null); // Intentional. Mr. Balatrez wont Display on the Player
            ItemAPI.Add(new CustomItem(balatroJoker, displayRules));
        }
    }
}
