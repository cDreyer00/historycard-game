using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon.StructWrapping;

public class CardsManager : MonoBehaviourPunCallbacks
{
    public Sprite[] cards;

    bool CanInteract;

    void Start()
    {
        CanInteract = true;
    }

    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (photonView.IsMine)
        {
            if (CanInteract && PlayerListing.instance.myTurn)
            {
                photonView.RPC("PickCard", RpcTarget.All, Random.Range(0, cards.Length));
            }
        }
    }

    [PunRPC]
    void PickCard(int card)
    {
        // cria uma carta aleatória dentre as opções
        GameObject CardObject = new GameObject("Card from " + gameObject.name, typeof(SpriteRenderer), typeof(BoxCollider2D));


        CardObject.transform.localScale = transform.localScale;
        CardObject.transform.position = transform.position - new Vector3(0, 2, 0);
        CardObject.GetComponent<SpriteRenderer>().sprite = cards[card];
        CardObject.GetComponent<BoxCollider2D>().size = gameObject.GetComponent<BoxCollider2D>().size;

        CardObject.AddComponent<VisualizeCard>();

        transform.position = transform.position + new Vector3(0, 2, 0); // sobe o deck de cartas ja retirada

        CanInteract = false; // impede de interagir novamente
        
    }
}
