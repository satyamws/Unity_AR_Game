using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject arCamera;
    internal float damage = 1;  
    private float playerHealth = 5;
    private float enemyHealth = 1;

    //public void EnemyHealth()
    //{
    //    if (LevelPlay.currentIndex == 0)
    //    {
    //        damage = 1;
    //    }
    //    else if (LevelPlay.currentIndex == 1)
    //    {
    //        damage = 0.5f;
    //    }
    //    else if (LevelPlay.currentIndex == 2)
    //    {
    //        damage = 0.25f;
    //    }
    //}

    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            Debug.Log("Hit: " + hit.collider.name);

            if (hit.collider.name == "Enemy_Large(Clone)" || hit.collider.name == "Enemy_Small(Clone)")
            {
                EnemyAI enemy = hit.collider.GetComponent<EnemyAI>();

                if (enemy != null)
                {
                    //EnemyHealth();
                    enemy.TakeDamage(damage, enemyHealth); 
                }
            }
        }
    }
}
