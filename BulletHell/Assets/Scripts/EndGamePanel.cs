using TMPro;
using UnityEngine;

public class EndGamePanel : MonoBehaviour
{
    public TMP_Text panelText;

    void OnEnable()
    {
        if(GameManager.instance.isWinner)
            panelText.text = "Victory";
        else
            panelText.text = "Defeat";
    }

    public void ResetGame(string scene)
    {
        UIController.instance.LoadSelectedScene(scene);
    }

    public void Quit()
    {
        UIController.instance.ExitGame();          
    }

    public void Menu(string scene)
    {
        UIController.instance.LoadSelectedScene(scene);
    }

}
