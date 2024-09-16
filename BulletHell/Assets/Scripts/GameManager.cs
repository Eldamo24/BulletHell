using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isWinner;
    public int enemiesDefeated;

    void Start()
    {
        instance = this;
        enemiesDefeated = 0;
    }

    public void AddEnemyDefeated()
    {
        enemiesDefeated++;
        UIController.instance.UpdateEnemiesText();
    }
}
