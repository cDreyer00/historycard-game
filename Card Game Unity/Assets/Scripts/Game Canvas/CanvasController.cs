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

    PhotonView pv;
    private void Start()
    {
        pv = GetComponent<PhotonView>();
        roomCode.text = Connection.RoomCode; // mostra o código da sala no canvas

    }

}
