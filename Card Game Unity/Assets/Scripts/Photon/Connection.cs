using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Connection : MonoBehaviourPunCallbacks
{
    public static Connection instance;

    public static string RoomCode;
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

        RandomKey();
        Debug.Log("the room code is: " + RoomCode);
        PhotonNetwork.CreateRoom(RoomCode, roomOptions);

        PhotonNetwork.LoadLevel("Game Scene");
    }
    public override void OnConnected()
    {
        Debug.Log("connected");

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("joined room");
    }

    
    void RandomKey()
    {
        int charAmount = Random.Range(4, 5);
        const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";

        for (int i = 0; i < charAmount; i++)
        {
            RoomCode += glyphs[Random.Range(0, glyphs.Length)];
        }
    }
}
