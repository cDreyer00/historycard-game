using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CardsBehaviour : MonoBehaviour
{
    public static CardsBehaviour instance;

    public PhotonView pv;

    public GameObject cardsPrefab;
    private void Awake()
    {
        instance = this;
        pv = GetComponent<PhotonView>();
    }

    [PunRPC]
    public void ResetCards()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<CardsManager>() != null)
            {
                transform.GetChild(i).GetComponent<CardsManager>().RestartCards();
            }
        }
    }
}
