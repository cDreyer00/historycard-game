using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    string button;

    private void Start()
    {

    }

    public void MenuTransition(string button)
    {
        if(button == "Play")
        {
            Debug.Log("jogar");
        }
        else if (button == "Options")
        {
            Debug.Log("opções");

        }
        else if (button == "Quit")
        {
            Debug.Log("Sair");
        }
    }
}
