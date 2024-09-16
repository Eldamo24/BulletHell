using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public GameObject creditsPanel;
    public GameObject mainMenuPanel;
    
    void Start()
    {
        instance = this;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Prototype");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void Back()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
}
