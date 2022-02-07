using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviourPunCallbacks
{
    public static CanvasController instance;

    public GameObject startGamePanel, waitingPanel;

    public GameObject visualizePanel;


    public TextMeshProUGUI roomCode;
    public TextMeshProUGUI timerText;

    PhotonView pv;

    private void Start()
    {
        instance = this;

        pv = GetComponent<PhotonView>();
        roomCode.text = Connection.RoomCode; // mostra o código da sala no canvas

        PhotonNetwork.Instantiate("Player_Holder", transform.position, transform.rotation);

    }


    public void ReturnToMenuButton()
    {
        for (int i = 0; i < PlayerListing.instance.players.Count; i++)
        {
            if (PlayerListing.instance.players[i].pvIsMine)
            {
                PlayerListing.instance.pv.RPC("PlayerOut", RpcTarget.All, i);
            }
        }

    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void StartGame()
    {
        PlayerListing.instance.pv.RPC("TurnCheck", RpcTarget.AllBuffered, true);
    }
    public void PassTurn()
    {
        PlayerListing.instance.pv.RPC("TurnCheck", RpcTarget.AllBuffered, false);
    }
}
