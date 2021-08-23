﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


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
            PlayerPrefs.SetString("Nick", MenuController.instance.nickNameCreateIF.text);
        }
        else
        {
            JoinExistentRoom();
            PhotonNetwork.JoinRoom(MenuController.instance.roomCodeIF.text);
            PlayerPrefs.SetString("Nick", MenuController.instance.nickNameJoinIF.text);
            
            
        }
    }
    
    public override void OnConnected()
    {
        Debug.Log("connected");


    }

    public override void OnJoinedRoom()
    {
        Debug.Log("joined room");
        PhotonNetwork.LoadLevel("Game Scene");

    }

    void JoinExistentRoom()
    {
        Debug.Log("Entering...");


    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("cannot join the room " + message);
        PhotonNetwork.Disconnect();
    }

    void CreateRoom()
    {
        Debug.Log("Creating...");

        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 5 }; // cria sala

        RandomKey();
        Debug.Log("the room code is: " + RoomCode);
        PhotonNetwork.CreateRoom(RoomCode, roomOptions);



    }
    public override void OnCreatedRoom()
    {
        Debug.Log("room created");

    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Cannot create the room");
    }

    //gerador de senha de sala
    void RandomKey()
    {
        int charAmount = Random.Range(4, 5);
        const string glyphs = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        for (int i = 0; i < charAmount; i++)
        {
            RoomCode += glyphs[Random.Range(0, glyphs.Length)];
        }
    }
}
