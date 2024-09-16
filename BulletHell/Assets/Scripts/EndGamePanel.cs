using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGamePanel : MonoBehaviour
{
    public TMP_Text panelText;
    public bool isWinner;

    void OnEnable()
    {
        if (isWinner)
            panelText.text = "Victory";
        else
            panelText.text = "Defeat";
    }

    public void ResetGame()
    {
        UIController.instance.PlayGame();
    }

    public void Quit()
    {
        UIController.instance.ExitGame();          
    }

    public void Menu()
    {
        UIController.instance.Menu();
    }


}
