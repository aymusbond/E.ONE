using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using GoogleARCore;

public class Player_Manager : MonoBehaviourPunCallbacks
{
    //public ARCoreWorldOriginHelper_ ARCoreWorldOriginHelper;
    public Vector3 pos = new Vector3(-0.26f, -4.24f, -3.88f);
    // Start is called before the first frame update


    void Start()
    {
        if(photonView.IsMine)
        {
            CreateController();
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    void CreateController()
    {
        if(PhotonNetwork.IsMasterClient)
        {
        GameObject player = (GameObject)PhotonNetwork.InstantiateSceneObject("player", Vector3.zero , Quaternion.identity, 0, null);
        player.GetComponent<PhotonView>().RPC("SetTeamID", RpcTarget.AllBuffered, 9);
        }
    }

    /*void SetWorldOrigin(Transform player)
    {
        ARCoreWorldOriginHelper.SetWorldOrigin(player);
    }*/
}
