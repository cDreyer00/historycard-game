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

    public bool gameStarted;

    private void Start()
    {
        instance = this;

        pv = GetComponent<PhotonView>();
        roomCode.text = Connection.RoomCode; // mostra o código da sala no canvas

        PhotonNetwork.Instantiate("Player_Holder", transform.position, transform.rotation);

        CheckStartGame();
    }

    public void CheckStartGame()
    {
        if (gameStarted)
        {
           startGamePanel.SetActive(false);
           waitingPanel.SetActive(false);
        }
    }

    public void ReturnToMenuButton()
    {
        PhotonNetwork.Disconnect();
    }

    public void StartGame()
    {
        PlayerListing.instance.pv.RPC("TurnCheck", RpcTarget.AllBufferedViaServer);
    }
    public void PassTurn()
    {
        var playerList = PlayerListing.instance.players;
        for (int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i].player.myTurn && playerList[i].player.pvIsMine)
            {
                PlayerListing.instance.pv.RPC("TurnCheck", RpcTarget.AllBufferedViaServer);
            }
            else if(playerList[i].player.myTurn && !playerList[i].player.pvIsMine)
            {
                Debug.Log("Isnt my turn");
            }
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        SceneManager.LoadScene("Main Menu");
    }
}
