using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI roomCode;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI playerNameText;


    private void Start()
    {
        roomCode.text = Connection.RoomCode; // mostra o código da sala no canvas

        photonView.RPC("NewPlayer", RpcTarget.AllBuffered, PlayerPrefs.GetString("Nick"));
        //NewPlayer(PlayerPrefs.GetString("Nick"));
    }

    [PunRPC]
    public void NewPlayer(string Nick)
    {
        GameObject newText = Instantiate(playerNameText.gameObject, transform.position, transform.rotation);

        newText.transform.parent = playerNameText.transform.parent;

        newText.GetComponent<TextMeshProUGUI>().text = Nick;

    }
}
