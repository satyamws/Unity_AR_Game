using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelPlay : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown levelDropdown;
    [SerializeField] private GameObject LevelPrefab;
    public List<GameObject> GameLevels; 
    public static int currentIndex = 0;
    private static string selectedCharacter;
    public Material[] player_LevelMaterials;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;
    public EnemySpawner enemySpawner;
    public List<Toggle> toggles = new();
    public GameObject player;
    public GameObject levelCompletePanel;

    private void Start()
    {
        if (levelDropdown != null)
        {
            levelDropdown.onValueChanged.AddListener(UpdateCurrentIndex);
        }

        foreach (var toggle in toggles)
        {
            toggle.onValueChanged.AddListener(state =>
            {
                if (state)
                {
                    Text Text = toggle.GetComponentInChildren<Text>();
                    if (Text != null)
                    {
                        selectedCharacter = Text.text;
                    }

                    Debug.Log("Selected Character: " + selectedCharacter);
                }
            });
        }


        UpdateCurrentIndex(levelDropdown.value);
    }


    void UpdateCurrentIndex(int index)
    {
        currentIndex = index; 
        Debug.Log("Selected Level Index: " + currentIndex);
    }

    public void PlayGame()
    {
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        SelectPlayerMaterialFunc();
        ActivateGameLevels(currentIndex);
        enemySpawner.SpawnEnemies();
    }

    void SelectPlayerMaterialFunc()
    {
        if (selectedCharacter == "Green")
        {
            UIManager.playerHealth = 5;
            player.GetComponent<Renderer>().material.color = player_LevelMaterials[0].color;
        }
        else if (selectedCharacter == "Yellow")
        {
            UIManager.playerHealth = 7;
            player.GetComponent<Renderer>().material.color = player_LevelMaterials[1].color;
        }
        else if (selectedCharacter == "Blue")
        {
            UIManager.playerHealth = 10;
            player.GetComponent<Renderer>().material.color = player_LevelMaterials[2].color;
        }
    }

    public void SwitchToNext()
    {
        if (GameLevels.Count == 0) return;

        GameLevels[currentIndex].SetActive(false);

        currentIndex = (currentIndex + 1) % GameLevels.Count;

        ActivateGameLevels(currentIndex);
        enemySpawner.SpawnEnemies();
    }

    private void ActivateGameLevels(int index)
    {
        foreach (GameObject obj in GameLevels)
        {
            obj.SetActive(false);
        }

        if (index >= 0 && index < GameLevels.Count)
        {
            GameLevels[index].SetActive(true);
        }
        else
        {
            Debug.LogError("Invalid level index: " + index);
        }
    }
    public void MainMenuBtnFunc()
    {
        gameWinPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        enemySpawner.enemyCount = 10;
        UIManager.totalEnemies = 10;
        UIManager.playerHealth = 5;
        levelCompletePanel.SetActive(false);
    }
}


