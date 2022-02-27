 using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    public static PlayerListing instance; // singleton 

    [HideInInspector] 
    public PhotonView pv;

    public List<AddPlayer> players = new List<AddPlayer>();
    public int curTurn;

    private void Awake()
    {
        instance = this;
        pv = GetComponent<PhotonView>();
    }

    public void Update()
    {
        foreach (var element in players)
        {
            if (element.player == null)
            {
                Destroy(element.playerNick);
                players.Remove(element);
                instance.pv.RPC("TurnCheck", RpcTarget.AllBufferedViaServer);
            }
        }
    }

    [PunRPC]
    public void TurnCheck() // checagem de turnos
    {
        if (CanvasController.instance.gameStarted)
        {
            curTurn++;
        }
        else
        {
            CanvasController.instance.gameStarted = true;
            CanvasController.instance.CheckStartGame();
        }

        if (curTurn >= players.Count)
        {
            curTurn = 0;
        }
        
        for (int i = 0; i < players.Count; i++)
        {
            if(i == curTurn)
            {
                players[i].player.myTurn = true;
            }
            else
            {
                players[i].player.myTurn = false;
            }
        }

        CardsBehaviour.instance.pv.RPC("ResetCards", RpcTarget.AllBuffered);
    }
}

public class AddPlayer
{
    public PlayerManager player;
    public GameObject playerNick;
}
