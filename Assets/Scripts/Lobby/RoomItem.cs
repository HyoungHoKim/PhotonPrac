using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class RoomItem : MonoBehaviour
{
    #region Pulbic Fields
    public Text roomName;
    LobbyManager manager;
    #endregion

    #region MonoBehaviour CallBacks
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<LobbyManager>();
    }
    #endregion

    #region Public Methods
    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName;
    }

    public void OnClickItem()
    {
        manager.JoinRoom(roomName.text);
    }
    #endregion
}
