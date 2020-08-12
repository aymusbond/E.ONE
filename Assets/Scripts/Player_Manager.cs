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

        //pos = new Vector3(-0.26f, -4.24f, -3.88f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateController()
    {
        GameObject player = PhotonNetwork.Instantiate("Player", Vector3.zero , Quaternion.identity, 0) as GameObject;
        //SetWorldOrigin(player.transform);
    }

    /*void SetWorldOrigin(Transform player)
    {
        ARCoreWorldOriginHelper.SetWorldOrigin(player);
    }*/
}
