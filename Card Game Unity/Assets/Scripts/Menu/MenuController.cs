using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    #region Variables
    //Public
    public GameObject mainMenuPanel;
    public GameObject connectionsPanel;
    public GameObject optionsPanel;

    //Private

    #endregion

    private void Start()
    {

    }


    //Change menu according to the string set in the button
    public void MenuTransition(string button)
    {
        //Main menu buttons
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
            Application.Quit();
        }
    }
}
