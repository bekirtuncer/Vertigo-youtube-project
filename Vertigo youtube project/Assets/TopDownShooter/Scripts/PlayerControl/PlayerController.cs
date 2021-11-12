using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using TopDownShooter.Network;
using UnityEngine;
using NetworkPlayer = TopDownShooter.Network.NetworkPlayer;
using UniRx;
using System;
using TopDownShooter.Stat;

namespace TopDownShooter
{
    public class PlayerController : MonoBehaviour, IPlayerStatHolder
    {
        [SerializeField] private DamagebleObjectBase[] _damagebleObjectBases;
        [SerializeField] private NetworkPlayer _networkPlayer;
        [SerializeField] protected PlayerInventoryController _inventoryController;

        public PlayerStat PlayerStat { get; set; }

        protected void Start()
        {
            _networkPlayer.RegisterStatHolder(_inventoryController);
            _networkPlayer.PlayerStat.OnDeath.Subscribe(OnDeath).AddTo(gameObject);
            for (int i = 0; i < _damagebleObjectBases.Length; i++)
            {
                _networkPlayer.RegisterStatHolder(_damagebleObjectBases[i]);
            }
            _networkPlayer.RegisterStatHolder(this);
        }

        public void SetStat(PlayerStat stat)
        {
            PlayerStat = stat;
            stat.OnDeath.Subscribe(OnDeath).AddTo(gameObject);
        }

        private void OnDeath(Unit obj)
        {
            if (_networkPlayer.PlayerStat.IsLocalPlayer)
            {
                MatchmakingController.Instance.LeaveRoom();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        
    }    
}
