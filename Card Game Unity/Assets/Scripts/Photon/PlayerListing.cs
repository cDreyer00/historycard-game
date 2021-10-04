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
    public List<GameObject> players = new List<GameObject>();

    public static int curTurn;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        pv = GetComponent<PhotonView>();
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
        newText.GetComponent<TextMeshProUGUI>().fontSize = 30;

    }

    [PunRPC]
    public void TurnCheck(bool _MyTurn) // Muda a cor do nick de acordo com o turno do player
    {
        if (_MyTurn)
        {
            Debug.Log("Meu turno");
            myTurn = _MyTurn;
            myNick.color = Color.green;
        }
        else
        {
            Debug.Log("Passei turno");
            myTurn = _MyTurn;
            myNick.color = Color.white;
        }
    }

}
