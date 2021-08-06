using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    #region Variables
    //Public
    public static MenuController instance;

    [Space]
    [Header("Panels")]
    public GameObject mainMenuPanel; 
    public GameObject connectionsPanel;
    public GameObject optionsPanel;

    [Space]
    [Header("Connection Panels")]
    public GameObject enterRoomPanel;
    public GameObject createRoomPanel;


    [Space]
    [Header("InputFields")]
    public TMP_InputField nickNameJoinIF;
    public TMP_InputField nickNameCreateIF;
    public TMP_InputField roomCodeIF;
    //Private
    #endregion

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //set the main menu as active only
        mainMenuPanel.SetActive(true);
        connectionsPanel.SetActive(false);
        optionsPanel.SetActive(false);
        enterRoomPanel.SetActive(false);
        createRoomPanel.SetActive(false);

        
    }


    //Change menu according to the string set in the button
    public void MenuTransition(string button)
    {
        //Close game
        if (button == "Quit")
        {
            Application.Quit();
        }
        //Enter a room
        else if(button == "Enter Room")
        {
            Connection.instance.Connect();
            Connection.Create = false;
        }
        //Create and connect to a room
        else if (button == "Create Room")
        {
            Connection.instance.Connect();
            Connection.Create = true;


        }
    }
}


