using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonGameManager : MonoBehaviourPunCallbacks
{
    public static PhotonGameManager instance;

    public GameObject GamePanel;


    PhotonView pv;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        pv = GetComponent<PhotonView>();


        GameObject newPlayerListingObject = PhotonNetwork.Instantiate("Player_Listing_Panel", transform.position, transform.rotation);
        newPlayerListingObject.transform.SetParent(GamePanel.transform, false);

    }
}
