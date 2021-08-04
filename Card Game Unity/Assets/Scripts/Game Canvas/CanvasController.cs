using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public TextMeshProUGUI roomCode;

    private void Start()
    {
        roomCode.text = Connection.RoomCode; // mostra o código da sala no canvas
    }
}
