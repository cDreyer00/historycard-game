using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    public static PlayerListing instance; // singleton 

    PhotonView pv;

    private void Awake()
    {
        instance = this; // refereincia o singleton
    }
    private void Start()
    {
        // referencia o PV e puxa a função de lsitar player
        pv = GetComponent<PhotonView>();
        pv.RPC("NewPlayer", RpcTarget.AllBuffered, PlayerPrefs.GetString("Nick"));
    }

    
    void Update()
    {
        
    }

    [PunRPC]
    public void NewPlayer(string Nick) // cria objeto no canvas de texto com o nome do player que conectou
    {
        GameObject newText = PhotonNetwork.Instantiate("Player_Nick", transform.position, transform.rotation);

        newText.transform.SetParent(this.transform);

        newText.GetComponent<TextMeshProUGUI>().text = Nick;

    }
}
