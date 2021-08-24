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
        instance = this;
    }
    private void Start()
    {
        // referencia o PV e puxa a função de listar player
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
        newText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        newText.GetComponent<TextMeshProUGUI>().text = Nick;

    }
}
