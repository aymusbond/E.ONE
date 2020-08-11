using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomList : MonoBehaviour
{
    RoomInfo info;
    public Text text;

    public void SetUp(RoomInfo _info)
    {
        info = _info;
        text.text = _info.Name;
    }
}
