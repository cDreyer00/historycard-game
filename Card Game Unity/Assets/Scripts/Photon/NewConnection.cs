using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NewConnection : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnected()
    {
        Debug.Log("Connected");
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 5 };

        PhotonNetwork.JoinOrCreateRoom("salateste", roomOptions, null);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game Scene");
    }
}
