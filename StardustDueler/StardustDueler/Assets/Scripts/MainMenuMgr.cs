using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuMgr : MonoBehaviour
{
    public GameObject duelbutton;
    public GameObject deckButton;
    public GameObject cardDBButton;
    public GameObject CCGButton;
    public GameObject aboutButton;
    public GameObject exitButton;
    private readonly string[] directories = { "UserContent", "Database" };
    void Start()
    {
        //Register buttons
        if (duelbutton.GetComponent("MMButtonManager") == null) duelbutton.SetActive(false);
        if (deckButton.GetComponent("MMButtonManager") == null) deckButton.SetActive(false);
        if (cardDBButton.GetComponent("MMButtonManager") == null) cardDBButton.SetActive(false);
        if (CCGButton.GetComponent("MMButtonManager") == null) CCGButton.SetActive(false);
        if (aboutButton.GetComponent("MMButtonManager") == null) aboutButton.SetActive(false);
        if (exitButton.GetComponent("MMButtonManager") == null) exitButton.SetActive(false);
        //Set up directories
        foreach (string s in directories) { DSCheck(s); }
        
    }

    /// <summary>
    /// Makes sure we have needed files/folders
    /// </summary>
    void DSCheck(string fOf)
    {
        if (!Directory.Exists($"{System.Environment.CurrentDirectory}/{fOf}")) Directory.CreateDirectory($"{System.Environment.CurrentDirectory}/{fOf}");
        return;
    }

}
