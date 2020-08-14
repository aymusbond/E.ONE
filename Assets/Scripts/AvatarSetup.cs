using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class AvatarSetup : MonoBehaviourPunCallbacks
{
    private PhotonView pv;
    private int characterValue;
    public GameObject myCharacter;

    public int playerHealth;
    public int playerDamage;
    void Start()
    {
        pv = GetComponent<PhotonView>();    
        if(pv.IsMine)
        {
            pv.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, myCharacter);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
