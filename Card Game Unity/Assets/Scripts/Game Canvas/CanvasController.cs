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
    public GameObject visualizePanel;

    public TextMeshProUGUI roomCode;
    public TextMeshProUGUI timerText;

    PhotonView pv;
    private void Start()
    {
        instance = this;

        pv = GetComponent<PhotonView>();
        roomCode.text = Connection.RoomCode; // mostra o código da sala no canvas

        visualizePanel = GameObject.Find("CardsVisualizer_Panel");
        visualizePanel.SetActive(false);

        PhotonNetwork.Instantiate("Player_Holder", transform.position, transform.rotation);

    }


    public void ReturnToMenuButton()
    {
        PhotonNetwork.Disconnect();
    }

    public void PassTurn()
    {
        PlayerListing.instance.pv.RPC("TurnCheck", RpcTarget.AllBuffered, false);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        SceneManager.LoadScene("Main Menu");
    }
}
