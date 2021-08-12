using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    public static PlayerListing instance;

    PhotonView pv;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        pv = GetComponent<PhotonView>();

        pv.RPC("NewPlayer", RpcTarget.AllBuffered, PlayerPrefs.GetString("Nick"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    public void NewPlayer(string Nick)
    {
        GameObject newText = PhotonNetwork.Instantiate("Player_Nick", transform.position, transform.rotation);

        newText.transform.parent = this.transform;

        newText.GetComponent<TextMeshProUGUI>().text = Nick;

    }
}
