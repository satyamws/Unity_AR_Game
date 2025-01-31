using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 5;

    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
            Instantiate(enemyPrefab, randomPos, Quaternion.identity);
        }
    }
}

