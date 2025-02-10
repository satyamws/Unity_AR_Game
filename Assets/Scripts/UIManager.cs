using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text enemyCountText;
    public TMP_Text playerHealthText;
    public GameObject gameOverPanel; 
    public GameObject gameWinPanel;
    public GameObject gameCompletePanel;

    public static int totalEnemies = 10;
    public static int playerHealth = 5; 

    void Start()
    {
        UpdateUI();
    }

    public void EnemyDefeated()
    {
        totalEnemies--;
        UpdateUI();
        HealthStatus();


    }

    void HealthStatus()
    {
        if (totalEnemies <= 0 && LevelPlay.currentIndex < 2)
        {
            gameWinPanel.SetActive(true);
        }
        else if (totalEnemies == 0 && LevelPlay.currentIndex == 2)
        {
            gameCompletePanel.SetActive(true);
        }
    }

    public void PlayerHit()
    {
        playerHealth--;
        UpdateUI();

        if (playerHealth <= 0)
        {
            Debug.Log("Game Over!");

            GameObject[] enemyClones = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemyClones)
            {
                Destroy(enemy);
            }

            gameOverPanel.SetActive(true);
        }

        HealthStatus();
    }

    void UpdateUI()
    {
        enemyCountText.text = "Enemies Left: " + totalEnemies;
        playerHealthText.text = "Health: " + playerHealth;
    }
}
