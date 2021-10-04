using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    PhotonView pv;

    public string nickName;
    public bool myTurn;

    public bool pvIsMine;
    private void Start()
    {
        pv = GetComponent<PhotonView>();
        if (!pv.IsMine)
        {
            pvIsMine = false;
            GameObject.Find("Player_Listing").GetComponent<PlayerListing>().players.Add(gameObject);

        }
        else
        {
            pvIsMine = true;
            nickName = PlayerPrefs.GetString("Nick");

            GameObject.Find("Player_Listing").GetComponent<PlayerListing>().pv.RPC("NewPlayer", RpcTarget.AllBuffered, nickName);

            GameObject.Find("Player_Listing").GetComponent<PlayerListing>().players.Add(gameObject);
        }
    }
}
