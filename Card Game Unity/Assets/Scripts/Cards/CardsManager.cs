using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public Sprite[] cards;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GameObject Card = new GameObject("card from" + gameObject.name, typeof(SpriteRenderer), typeof(BoxCollider));
        Card.transform.position = transform.position - new Vector3(0, 3, 0);
        Card.GetComponent<SpriteRenderer>().sprite = cards[Random.Range(0, cards.Length)];
    }
}
