using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public GameObject selectLevelPanel;
    public GameObject instructions;
    public GameObject creditsPanel;
    public GameObject mainMenuPanel;
    public GameObject EndGamePanel;
    public GameObject InGameUI;
    public TMP_Text enemiesAmountText;
    public TMP_Text lifeText;
    public Texture2D cursorHandTexture;
    private Texture2D defaultCursor;

    void Start()
    {
        instance = this;
        defaultCursor = null;
        if(SceneManager.GetActiveScene().name == "Prototype" || SceneManager.GetActiveScene().name == "Level1")
        {
            UpdateEnemiesText();
            UpdateLifeText(100);
        }
    }

    public void PlayGame()
    {
        mainMenuPanel.SetActive(false);
        selectLevelPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void Instructions()
    {
        instructions.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void Back(string panel)
    {
        mainMenuPanel.SetActive(true);
        if (panel == "Credits")
            creditsPanel.SetActive(false);
        else if (panel == "SelectLevel")
            selectLevelPanel.SetActive(false);
        else if(panel == "Instructions")
            instructions.SetActive(false);

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

    public void LoadSelectedScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SetCursorOver()
    {
        Cursor.SetCursor(cursorHandTexture, Vector2.zero, CursorMode.Auto);
    }

    public void SetCursorExit()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }
}
