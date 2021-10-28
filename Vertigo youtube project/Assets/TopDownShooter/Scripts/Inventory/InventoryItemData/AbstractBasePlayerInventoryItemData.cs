using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Inventory
{
    public abstract class AbstractBasePlayerInventoryItemData : ScriptableObject
    {
        private PlayerInventoryController _inventoryController;
        protected CompositeDisposable _compositeDisposable;
        public virtual void Initialize(PlayerInventoryController targetPlayerInventory)
        {
            _inventoryController = targetPlayerInventory;
            _compositeDisposable = new CompositeDisposable();
        } 

        public virtual void Destroy()
        {
            // means that we are unsubscribing from all the events we add to this
            _compositeDisposable.Dispose();
            Destroy(this);
        }
    }
}
