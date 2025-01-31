using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    [SerializeField] public int enemyCount;
    public float spawnRadiusMin = 10f;  
    public float spawnRadiusMax = 20f; 
    public Transform player;  
    public GameObject enemyParentGO;
    public UIManager manager;

    void ChangeEnemyHealth()
    {
        GameObject[] enemyClones = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject go in enemyClones)
        {
            if(LevelPlay.currentIndex == 0)
            {
                go.GetComponent<EnemyAI>().health = 1;
            }
            else if(LevelPlay.currentIndex == 1)
            {
                go.GetComponent<EnemyAI>().health = 2;
            }
            else if (LevelPlay.currentIndex == 2)
            {
                go.GetComponent<EnemyAI>().health = 3;
            }
        }
    }

    void CalculateEnemyCount()
    {
        if (LevelPlay.currentIndex == 0)
        {
            enemyCount = 10;

        }
        else if (LevelPlay.currentIndex == 1)
        {
            enemyCount = 15;
        }
        else if (LevelPlay.currentIndex == 2)
        {
            enemyCount = 20;
        }

        UIManager.totalEnemies = enemyCount;
    }

    public void SpawnEnemies()
    {
        

        CalculateEnemyCount();

        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPosition = GetValidSpawnPosition();

            GameObject selectedEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            Quaternion lookRotation = Quaternion.LookRotation(player.position - spawnPosition);

            Instantiate(selectedEnemy, spawnPosition, lookRotation);

        }

        ChangeEnemyHealth();

        manager.enemyCountText.text = "Enemies Left: " + UIManager.totalEnemies.ToString();
        enemyCount += 5;
    }

    Vector3 GetValidSpawnPosition()
    {
        Vector3 spawnPos;
        float distance;

        do
        {
            float randomAngle = Random.Range(0f, 360f);
            float randomDistance = Random.Range(spawnRadiusMin, spawnRadiusMax);

            spawnPos = new Vector3(
                player.position.x + Mathf.Cos(randomAngle) * randomDistance,
                0,
                player.position.z + Mathf.Sin(randomAngle) * randomDistance
            );

            distance = Vector3.Distance(player.position, spawnPos);

        } while (distance < spawnRadiusMin); 

        return spawnPos;
    }
}
