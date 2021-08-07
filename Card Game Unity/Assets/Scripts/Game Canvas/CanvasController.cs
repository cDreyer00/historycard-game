using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public TextMeshProUGUI roomCode;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI playerNameText;


    private void Start()
    {
        roomCode.text = Connection.RoomCode; // mostra o código da sala no canvas

        Debug.Log("your name is: " + PlayerPrefs.GetString("Nick"));
        playerNameText.text = PlayerPrefs.GetString("Nick");

    }
}
