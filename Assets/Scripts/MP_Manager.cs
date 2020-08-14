using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class MP_Manager : MonoBehaviourPunCallbacks
{
    public InputField enterroomID; 
    public Text errorDisplay;
    public Text RoomName_Display;

    public GameObject[] DisableOnConnected;
    public GameObject[] EnableOnConnected;
    public GameObject[] DisableOnJoinedRoom;
    //public GameObject[] EnableOnJoinedRoom;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }  

    public override void OnConnectedToMaster()
    {
        foreach(GameObject disable in DisableOnConnected)
        {
            disable.SetActive(false);
        }
        PhotonNetwork.JoinLobby();
    }

    public void connectToMaster()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    
    public override void OnJoinedLobby()
    {
        foreach(GameObject enable in EnableOnConnected)
        {
            enable.SetActive(true);
        }
    }

    public void CreateRoom()
    {
        if(string.IsNullOrEmpty(enterroomID.text))
        {
            return;
        }
        
        PhotonNetwork.CreateRoom(enterroomID.text);
    }

    public override void OnJoinedRoom()
    {
        RoomName_Display.text = PhotonNetwork.CurrentRoom.Name;
        foreach(GameObject disable in DisableOnJoinedRoom)
        {
            disable.SetActive(false);
        }

        PhotonNetwork.LoadLevel(1);
        
        
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorDisplay.text = "Room Creation Failed! [ " + message + " ] ";
    } 

    public void OnLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        foreach(GameObject enable in EnableOnConnected)
        {
            enable.SetActive(true);
        }
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(enterroomID.text);
    }

    public override void OnJoinRoomFailed(short shortCode, string message)
    {
        errorDisplay.text = "Room Creation Failed! [ " + message +" ] ";
    }


}