using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textElement;
    //private GameManager gameManagerScript;
    public enum HudElements
    {
        Nothing,
        TextBuild
    }
    void Start()
    {
        /*if (gameManager == null)
            gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();*/
        textElement.enabled = false;
    }

    void Update()
    {
        /*if (gameManagerScript.IsGameOver())
            ShowGameOver();
        else
            RemoveGameOver();
        if (gameManagerScript.IsPauseGame())
            ShowPause();
        else
            RemovePause();*/
    }

    public void ActivateElement(HudElements el)
    {
        switch (el)
        {
            case HudElements.TextBuild:
                textElement.text = "[E] - to build";
                break;
        }
        textElement.enabled = true;
    }

    public void DesactivateElement()
    {
        textElement.enabled = false;
    }
}

