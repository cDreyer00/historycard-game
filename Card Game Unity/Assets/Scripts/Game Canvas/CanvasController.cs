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
    public TextMeshProUGUI playerNameText;

    PhotonView pv;
    private void Start()
    {
        instance = this;

        pv = GetComponent<PhotonView>();
        roomCode.text = Connection.RoomCode; // mostra o código da sala no canvas

        visualizePanel = GameObject.Find("CardsVisualizer_Panel");
        visualizePanel.SetActive(false);


    }


    public void ReturnToMenuButton()
    {
        PhotonNetwork.Disconnect();

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        SceneManager.LoadScene("Main Menu");
    }
}
