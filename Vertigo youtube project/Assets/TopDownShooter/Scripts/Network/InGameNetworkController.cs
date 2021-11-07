using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Network
{
    public class InGameNetworkController : Photon.PunBehaviour
    {
        [SerializeField] private NetworkPlayer _localPlayerPrefab;
        [SerializeField] private NetworkPlayer _remotePlayerPrefab;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(10);
            InstantiateLocalPlayer();   
        }
        public void InstantiateLocalPlayer()
        {
            var instantiated = Instantiate(_localPlayerPrefab);
            int viewId = PhotonNetwork.AllocateViewID();
            instantiated.SetOwnerShip(PhotonNetwork.player);
            instantiated.photonView.viewID = viewId;
            photonView.RPC("RPC_InstantiateLocalPlayer", PhotonTargets.OthersBuffered, viewId);
            PhotonNetwork.isMessageQueueRunning = true;
        }

        [PunRPC]
        public void RPC_InstantiateLocalPlayer(int viewId, PhotonMessageInfo photonMessageInfo)
        {
            Debug.Log("INSTANTIATE LOCAL PLAYER" + photonMessageInfo.sender.name);
            var instantaited = Instantiate(_remotePlayerPrefab);
            instantaited.photonView.viewID = viewId;
            instantaited.SetOwnerShip(photonMessageInfo.sender);
        }
    }    
}
