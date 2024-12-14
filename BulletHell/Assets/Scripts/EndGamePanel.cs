using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    public Sprite[] backImages;

    void OnEnable()
    {
        if (GameManager.instance.isWinner)
            gameObject.GetComponent<Image>().sprite = backImages[0];
        else
            gameObject.GetComponent<Image>().sprite = backImages[1];
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
