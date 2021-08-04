using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviourPunCallbacks
{
    public static Connection instance;
    private void Awake()
    {
        instance = this;
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master");
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, MaxPlayers = 5 };
        PhotonNetwork.CreateRoom("TestRoom", roomOptions);
    }
    public override void OnConnected()
    {
        Debug.Log("connected");

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("joined room");
    }
}
