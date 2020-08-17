
namespace GoogleARCore.Examples.CloudAnchors
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using GoogleARCore;
using GoogleARCore.CrossPlatform;

public class GameManager : MonoBehaviourPunCallbacks, IInRoomCallbacks
{

    private static GameManager instance; 
	public static GameManager Instance() { return instance;}
	void Awake () { instance = this; }

	//public GameObject playerPrefab;

    public Transform anchorTransform;
	
	//public Button spectateButton;

	//public TeamRuntimeSet teamOptions;

	[Header("Matchmaking Parameters")]
	//public string matchShortCode;
	public string matchGroup;

    public Text errorDisplay;
    
    public Camera fpsCam;
    public Vector3 pos = new Vector3(0.0f, 0.0f, 1f);
    public int count = 0;
    public GameObject Player;

    public bool isConnected = false;
    private Component m_LastPlacedAnchor = null;
    private ARKitHelper m_ARKit = new ARKitHelper();
    public Camera ARKitFirstPersonCamera;
    public InputField enterroomID; 

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        if(isConnected == true && count <= 2)
        {
            if(photonView.IsMine)
            {
                Touch touch;
                if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
                {
                    return;
                }

                // Raycast against the location the player touched to search for planes.
                if (Application.platform != RuntimePlatform.IPhonePlayer)
                {
                    TrackableHit hit;
                    if (Frame.Raycast(touch.position.x, touch.position.y,
                            TrackableHitFlags.PlaneWithinPolygon, out hit))
                    {
                        m_LastPlacedAnchor = hit.Trackable.CreateAnchor(hit.Pose);
                    }
                }
                else
                {
                    Pose hitPose;
                    if (m_ARKit.RaycastPlane(ARKitFirstPersonCamera, touch.position.x, touch.position.y, out hitPose))
                    {
                        m_LastPlacedAnchor = m_ARKit.CreateAnchor(hitPose);
                    }
                }

                if (m_LastPlacedAnchor != null)
                {
                    // Instantiate Andy model at the hit pose.
                    var andyObject = PhotonNetwork.Instantiate("Player", m_LastPlacedAnchor.transform.position,
                        m_LastPlacedAnchor.transform.rotation);

                    // Compensate for the hitPose rotation facing away from the raycast (i.e. camera).
                    //andyObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);

                    // Make Andy model a child of the anchor.
                    andyObject.transform.parent = m_LastPlacedAnchor.transform;

                    //m_LastPlacedAnchor.transform.position = Camera.main.transform.position;
                    count++;
                }
            }
        }
        else if(isConnected == true && count>=2)
        {
            return;
        }
        
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom()
    {
        if(string.IsNullOrEmpty(enterroomID.text))
        {
            return;
        }
        
        PhotonNetwork.CreateRoom(enterroomID.text);
    } 

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(enterroomID.text);
    }

    public override void OnCreatedRoom()
    {
        isConnected = true;
        errorDisplay.text =  "Room is created successfuly";
    }

    public override void OnJoinedRoom()
    {
        isConnected = true;
        errorDisplay.text =  "Room is joined successfuly";
    }

    public override void OnJoinRoomFailed(short returnCode, string 	message )
    {
        errorDisplay.text = "Room Join Failed! [ " + message + " ] ";
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorDisplay.text = "Room Creation Failed! [ " + message + " ] ";
    }

}
}
