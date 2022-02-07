using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NickPlayerCheck : MonoBehaviourPunCallbacks
{
    public GameObject player;

    PhotonView pv;
    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (player == null && pv.IsMine)
        {
            pv.RPC("PlayerDiconnected", RpcTarget.All);
        }
        else if (player == null && !pv.IsMine)
        {
            Destroy(gameObject);
        }
    }

    [PunRPC]
    public void PlayerDiconnected()
    {
        Destroy(gameObject);
    }
}
