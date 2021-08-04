using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
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

    void OnJoinedLobby()
    {
        Debug.Log("joined Loby");
    }
}
