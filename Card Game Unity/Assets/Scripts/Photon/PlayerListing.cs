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

    public List<PlayerManager> players = new List<PlayerManager>();

    public int curTurn;
    private void Awake()
    {
        instance = this;
        pv = GetComponent<PhotonView>();

    }


    [PunRPC]
    public void NewPlayer(string Nick, int playerID) // cria objeto no canvas de texto com o nome do player que conectou
    {

        GameObject newText = PhotonNetwork.Instantiate("Player_Nick", transform.position, transform.rotation);

        newText.transform.SetParent(this.transform);
        newText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        newText.GetComponent<TextMeshProUGUI>().text = Nick;

        //for (int i = 0; i < players.Count; i++)
        //{
        //    if(players[i].nickText == null)
        //    {
        //        players[i].nickText = newText.GetComponent<TextMeshProUGUI>();
        //        break;
        //    }
        //}
        
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            if(GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<PhotonView>().ViewID == playerID)
            {
                players.Add(GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<PlayerManager>());
                GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<PlayerManager>().nickText = newText.GetComponent<TextMeshProUGUI>();
            }
        }
    }

    [PunRPC]
    public void TurnCheck() // Muda a cor do nick de acordo com o turno do player
    {
        curTurn++;

        if (curTurn == players.Count)
        {
            curTurn = 0;
        }

        for (int i = 0; i < players.Count; i++)
        {
            if(i == curTurn)
            {
                players[i].myTurn = true;
            }
            else
            {
                players[i].myTurn = false;
            }
        }

        //if(curTurn == players.Count)
        //{
        //    curTurn = 0;

        //    players[curTurn].myTurn = true;
        //    for (int i = 0; i < players.Count; i++)
        //    {
        //        if(i != curTurn)
        //        {
        //            players[i].myTurn = false;
        //        }
        //    }

        //    if (players[curTurn].myTurn)
        //    {
        //        players[curTurn].nickText.color = Color.green;
        //    }
        //    else
        //    {
        //        players[curTurn].nickText.color = Color.white;
        //    }
        //}


    }

}
