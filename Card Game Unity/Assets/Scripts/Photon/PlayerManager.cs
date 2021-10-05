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

            nickName = PlayerPrefs.GetString("Nick");
            PlayerListing.instance.pv.RPC("NewPlayer", RpcTarget.AllBuffered, nickName, GetComponent<PhotonView>().ViewID);

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
