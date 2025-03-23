using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public int maxHealth = 10;
    private int currentHealth;

    public int attackDamage = 2;
    public float detectionRange = 30f;
    public float attackRange = 1f;
    public float attackCooldown = 0.5f;

    private Transform player;
    private bool isChasing = false;
    private bool isAttacking = false;

    public int expReward = 10;
    public int goldReward = 5;

    // Limites de la grille
    public float minX, maxX, minY, maxY;

    public Rigidbody2D rb;

    void Start()
    {
        Debug.Log("debut start enemy");

        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        
        Debug.Log("fin start enemy, scale : " + rb.gravityScale);

    }

    void Update()
    {
        Debug.Log("debut udpdate  enemy");

        if (player == null)
        {
            Debug.Log("udpdate  player null");

            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        Debug.Log("udpdate  distance player : " + distanceToPlayer);

        
        if (!isAttacking)
        {
            if (distanceToPlayer <= detectionRange && !isChasing)
            {
                Debug.Log("debut start  chaseing player");

                isChasing = true;
            }

            if (isChasing)
            {
                if (distanceToPlayer > attackRange)
                {
                    ChasePlayer();
                }
                else
                {         
                    Debug.Log(" udpdate  start attack player");

                    StartCoroutine(AttackPlayer());
                }
            }
        }
    }

    void ChasePlayer()
    {
        Debug.Log("debut chase player");

        Vector2 direction = (player.position - transform.position).normalized;
        Vector2 movement = direction * moveSpeed;
        
        Vector2 newPosition = (Vector2)transform.position + movement;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        if (newPosition.x == minX || newPosition.x == maxX || newPosition.y == minY || newPosition.y == maxY)
        {
            Debug.Log("Enemy hit limit");
        }
        
        transform.position = newPosition;
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;
        rb.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(attackCooldown);

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            player.GetComponent<PlayerController>()?.TakeDamage(attackDamage);
        }

        isAttacking = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //player.GetComponent<PlayerController>()?.GainXP(expReward);
        //player.GetComponent<PlayerController>()?.AddGold(goldReward);
        Destroy(gameObject);
    }

    void CastSpell()
    {
        // Code pour lancer des sorts si nécessaire
    }
}