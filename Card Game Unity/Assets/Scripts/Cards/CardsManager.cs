using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
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
        if (CanInteract)
        {
            // cria uma carta aleatória dentre as opções
            GameObject Card = new GameObject("Card from " + gameObject.name, typeof(SpriteRenderer), typeof(BoxCollider));
            Card.transform.position = transform.position - new Vector3(0, 2, 0);
            Card.GetComponent<SpriteRenderer>().sprite = cards[Random.Range(0, cards.Length)];

            transform.position = transform.position + new Vector3(0, 2, 0); // sobe o deck de cartas ja retirada

            CanInteract = false; // impede de interagir novamente
        }



    }
}
