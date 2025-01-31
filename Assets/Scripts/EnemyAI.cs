using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float health = 5;
    public float speed = 2.0f;
    private Transform player;
    private UIManager uiManager;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        uiManager = FindObjectOfType<UIManager>(); 
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        if (transform.position.x < 10.0f)
        {
            animator.SetTrigger("attack");
        }
        else
        {
            animator.SetTrigger("run");
        }
    }

    public void TakeDamage(float damage, float enemyHealth)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            uiManager.EnemyDefeated(); 
            Destroy(gameObject); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.totalEnemies--;
            uiManager.PlayerHit(); 
            Destroy(gameObject); 
        }
    }
}
