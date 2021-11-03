using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "TopDownShooter/Inventory/Player Inventory Cannon Item Data")]
    public class PlayerInventoryCannonItemData : AbstractPlayerInventoryItemData<PlayerInventoryCannonItemMono>, IDamage
    {
        [SerializeField] private float _damage;
        public float Damage { get { return _damage; } }
        [SerializeField] private float _rpm=1f;

        [Range(0.1f, 2)]
        [SerializeField] private float _armorPenetration = 3;
        public float ArmorPenetration { get { return _armorPenetration; } }

        public float RPM { get { return _rpm; } }
        private float _lastShootTime;
        public override void Initialize(PlayerInventoryController targetPlayerInventory)
        {
            base.Initialize(targetPlayerInventory);
            InstantiateAndInitializePrefab(targetPlayerInventory.CannonParent);
            targetPlayerInventory.ReactiveShootCommand.Subscribe(OnReactiveShootCommand)
                .AddTo(_compositeDisposable);
            Debug.Log("THIS CLASS IS PLAYER INVENTORY CANNON ITEM DATA");
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        private void OnReactiveShootCommand(Unit obj)
        {
            Debug.Log("reactive command shoot");
            Shoot();
        }

        public void Shoot()
        {
            if(Time.time - _lastShootTime > _rpm)
            {
                _instantiated.Shoot(this);
                _lastShootTime = Time.time;
            }
        }
    }
}
