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
        if(UIController.instance != null)
            UIController.instance.LoadSelectedScene(scene);
    }

    public void Quit()
    {
        if (UIController.instance != null)
            UIController.instance.ExitGame();          
    }

    public void Menu(string scene)
    {
        if (UIController.instance != null)
            UIController.instance.LoadSelectedScene(scene);
    }

}
