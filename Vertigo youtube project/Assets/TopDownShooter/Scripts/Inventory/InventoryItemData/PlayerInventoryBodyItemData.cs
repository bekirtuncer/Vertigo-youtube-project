using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "TopDownShooter/Inventory/Player Inventory Body Item Data")]
    public class PlayerInventoryBodyItemData : AbstractPlayerInventoryItemData<PlayerInventoryBodyItemMono>
    {
        public override void Initialize(PlayerInventoryController targetPlayerInventory)
        {
            var instantiated = InstantiateAndInitializePrefab(targetPlayerInventory.Parent);
            Debug.Log("THIS CLASS IS PLAYER INVENTORY BODY ITEM DATA");
        }
    }
}
