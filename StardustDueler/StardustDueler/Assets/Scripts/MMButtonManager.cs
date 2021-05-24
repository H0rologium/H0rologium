using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MMButtonManager : MonoBehaviour
{
    public Button duelButton, deckButton, cardDBButton, customButton, aboutButton, exitButton;
    void Start()
    {
        exitButton.onClick.AddListener(delegate { ButtonChoice("exit"); });
    }

    void ButtonChoice(string i)
    {
        switch (i)
        {
            case "exit":
                Application.Quit();
                return;
        }

    }
}
