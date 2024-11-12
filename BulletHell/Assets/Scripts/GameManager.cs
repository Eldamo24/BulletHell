using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isWinner = false;
    public int enemiesDefeated;

    void Start()
    {
        Time.timeScale = 1;
        instance = this;
        enemiesDefeated = 0;
    }

    public void AddEnemyDefeated()
    {
        enemiesDefeated++;
        if (UIController.instance != null) 
        {
            UIController.instance.UpdateEnemiesText();
        }
        CheckWin();
    }

    void CheckWin()
    {
        if(enemiesDefeated >= 21)
        {
            isWinner = true;
            if (UIController.instance != null) 
            {
                UIController.instance.WinOrDefeat();
            }
        }
    }

    public void CheckLoose()
    {
        isWinner = false;
        if (UIController.instance != null)
        {
            UIController.instance.WinOrDefeat();
        }
    }
}
