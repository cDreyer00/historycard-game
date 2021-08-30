using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    public static PlayerListing instance; // singleton 

    public TextMeshProUGUI myNick;
    public bool myTurn;

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
       
        if (pv.IsMine)
        {
            // chama a função que muda a cor do nick
            if (myTurn && myNick.color != Color.green)
            {
                pv.RPC("TurnCheck", RpcTarget.AllBuffered, true);
            }
            else if (!myTurn && myNick.color != Color.white)
            {
                pv.RPC("TurnCheck", RpcTarget.AllBuffered, false);
            }
        }
    }

    [PunRPC]
    public void NewPlayer(string Nick) // cria objeto no canvas de texto com o nome do player que conectou
    {
        GameObject newText = PhotonNetwork.Instantiate("Player_Nick", transform.position, transform.rotation);

        newText.transform.SetParent(this.transform);
        newText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        newText.GetComponent<TextMeshProUGUI>().text = Nick;

        myNick = newText.GetComponent<TextMeshProUGUI>();

    }

    [PunRPC]
    void TurnCheck(bool _MyTurn) // Muda a cor do nick de acordo com o turno do player
    {
        if (_MyTurn)
        {
            myNick.color = Color.green;
        }
        else
        {
            myNick.color = Color.white;
        }
    }

}
