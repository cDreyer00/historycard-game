using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    PhotonView pv;

    public string nickName;

    public bool myTurn;
    public bool pvIsMine;

    public TextMeshProUGUI nickText;
    private void Start()
    {
        pv = GetComponent<PhotonView>();

        if (pv.IsMine)
        {
            pvIsMine = true;


            //PlayerListing.instance.pv.RPC("NewPlayer", RpcTarget.AllBuffered, nickName, GetComponent<PhotonView>().ViewID);
            pv.RPC("AddToPlayers", RpcTarget.AllBuffered);
            PlayerListing.instance.newPlayer = this;
            //PlayerListing.instance.pv.RPC("NewPlayer", RpcTarget.AllBuffered, nickName);


            CardsManager._pm = this;

            if(PhotonNetwork.IsMasterClient)
                CanvasController.instance.waitingPanel.SetActive(false);
            else
               CanvasController.instance.startGamePanel.SetActive(false);
        }
        else
        {
            pvIsMine = false;
        }
    }

    [PunRPC]
    public void AddToPlayers()
    {
        PlayerListing.instance.players.Add(this);
        nickName = PlayerPrefs.GetString("Nick");

        GameObject newText = PhotonNetwork.Instantiate("Player_Nick", transform.position, transform.rotation);

        newText.transform.SetParent(PlayerListing.instance.transform);
        newText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        newText.GetComponent<TextMeshProUGUI>().text = nickName;

        nickText = newText.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (myTurn)
        {
            nickText.color = Color.green;
        }
        else
        {
            nickText.color = Color.white;
        }
    }
}
