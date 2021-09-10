using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizeCard : MonoBehaviour
{

    private void OnMouseUp()
    {
        ExpandCard();
    }

    public void ExpandCard()
    {
        CanvasController.instance.visualizePanel.SetActive(true);
        GameObject Card = CanvasController.instance.visualizePanel.transform.Find("Card Expanded").gameObject;

        Card.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
    }
}
