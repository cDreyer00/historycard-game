using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CardsManager : MonoBehaviourPunCallbacks
{
    public Sprite[] cards;

    bool CanInteract = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (photonView.IsMine)
        {
            if (CanInteract)
            {
                photonView.RPC("PickCard", RpcTarget.All, Random.Range(0, cards.Length));
            }
        }
    }

    [PunRPC]
    void PickCard(int card)
    {
        // cria uma carta aleatória dentre as opções
        GameObject CardObject = new GameObject("Card from " + gameObject.name, typeof(SpriteRenderer), typeof(BoxCollider));

        CardObject.transform.localScale = transform.localScale;
        CardObject.transform.position = transform.position - new Vector3(0, 2, 0);
        CardObject.GetComponent<SpriteRenderer>().sprite = cards[card];

        transform.position = transform.position + new Vector3(0, 2, 0); // sobe o deck de cartas ja retirada

        CanInteract = false; // impede de interagir novamente
    }
}
