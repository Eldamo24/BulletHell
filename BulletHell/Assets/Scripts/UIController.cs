using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public GameObject creditsPanel;
    public GameObject mainMenuPanel;
    public GameObject EndGamePanel;
    public GameObject InGameUI;
    public TMP_Text enemiesAmountText;
    public TMP_Text lifeText;
    
    void Start()
    {
        instance = this;
        UpdateEnemiesText();
        UpdateLifeText(100);
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

    public void UpdateEnemiesText()
    {
        enemiesAmountText.text = "Enemies Defeated: " + GameManager.instance.enemiesDefeated.ToString();
    }

    public void UpdateLifeText(int life)
    {
        lifeText.text = "Life: " + life;
    }

    public void WinOrDefeat()
    {
        EndGamePanel.SetActive(true);
        InGameUI.SetActive(false);
        Time.timeScale = 0f;
    }
}
