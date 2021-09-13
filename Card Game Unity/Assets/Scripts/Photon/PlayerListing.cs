using ExitGames.Client.Photon.StructWrapping;
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


    [HideInInspector] 
    public PhotonView pv;

    public int myID;
    public List<int> playerIDs = new List<int>();

    public static int curTurn;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        // referencia o PV e puxa a função de listar player
        pv = GetComponent<PhotonView>();

        if (pv.IsMine)
        {
            Debug.Log("Pv IS mine");

            pv.RPC("NewPlayer", RpcTarget.AllBuffered, PlayerPrefs.GetString("Nick"));
        }
        else
        {
            Debug.Log("Pv isnt mine");
            Destroy(gameObject);
            //pv.RPC("NewPlayer", RpcTarget.AllBuffered, PlayerPrefs.GetString("Nick"));

        }
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

        if (pv.IsMine)
        {
            myNick = newText.GetComponent<TextMeshProUGUI>();
            myID = newText.GetComponent<PhotonView>().ViewID;
        }

        playerIDs.Add(newText.GetComponent<PhotonView>().ViewID);

    }

    [PunRPC]
    public void TurnCheck(int turn) // Muda a cor do nick de acordo com o turno do player
    {
        if(curTurn >= playerIDs.Count)
        {
            curTurn = turn = 0;
        }

        if(myID == playerIDs[turn])
        {
            Debug.Log("Meu turno");
            myTurn = true;
            myNick.color = Color.green;
        }
        else
        {
            Debug.Log("Passei turno");
            myTurn = false;
            myNick.color = Color.white;
        }
    }

}
