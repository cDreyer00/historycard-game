using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Linq;

public class Connection : MonoBehaviourPunCallbacks
{
    public static Connection instance;

    public static string RoomCode;
    public static bool Create;
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

        if (Create)
        {
            CreateRoom();
        }
        else
        {
            JoinExistentRoom();
            PhotonNetwork.JoinRoom(MenuController.instance.roomCodeIF.text);
        }
    }
    public override void OnConnected()
    {
        Debug.Log("connected");

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("joined room");
    }

    void JoinExistentRoom()
    {
        Debug.Log("Entering...");
        

        // PhotonNetwork.LoadLevel("Game Scene");

    }

    void CreateRoom()
    {
        Debug.Log("Creating...");

        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, MaxPlayers = 5 }; // cria sala

        RandomKey();
        Debug.Log("the room code is: " + RoomCode);
        PhotonNetwork.CreateRoom(RoomCode, roomOptions);

        PhotonNetwork.LoadLevel("Game Scene");

    }


    //gerador de senha de sala
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
