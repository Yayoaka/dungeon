using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int attack = 20;
    public int magic = 15;

    public int gold = 0;
    public int currentXP = 0;
    public int currentLevel = 1;
    public int xpToNextLevel = 100;
    public float levelUpStatMultiplier = 1.2f;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform spriteTransform; // Nouveau : Référence au sprite enfant
    private Vector2 movement;
    
    public Transform attackPoint;
    public float attackRange = 1.5f;
    public LayerMask enemyLayers;
    private bool canMeleeAttack = true;
    private bool canCastSpell = true;

    private FireProjectile fireProjectile; // Référence au script de sort
    
    // Limites de la grille
    public float minX, maxX, minY, maxY;

    void Start()
    {
        currentHealth = maxHealth;
        fireProjectile = GetComponent<FireProjectile>(); // Récupère le script FireProjectile
        Debug.Log("test start player");
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
        Vector2 newPosition = (Vector2)transform.position + movement;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        Debug.Log("Pos X : " + newPosition.x);
        Debug.Log("Pos Y : " + newPosition.y);


        if (newPosition.x <= minX || newPosition.x >= maxX || newPosition.y <= minY || newPosition.y >= maxY)
        {
            Debug.Log("Player hit limit");
        }
        
        transform.position = newPosition;

        /*if (movement.x != 0)
        {
            spriteTransform.localScale = new Vector3(movement.x > 0 ? 1f : -1f, 1f, 1f);
        }*/
        
        /*if (Input.GetMouseButtonDown(0) && canMeleeAttack)
        {
            Debug.Log("test attack melée player");
            StartCoroutine(MeleeAttack());
        }*/

        /*if (Input.GetMouseButtonDown(1) && canCastSpell)
        {
            Debug.Log("test attack spell player");

            fireProjectile.CastSpell();
            canCastSpell = false;
            StartCoroutine(SpellCooldown());
        }*/
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    IEnumerator MeleeAttack()
    {
        canMeleeAttack = false;
        animator.SetTrigger("MeleeAttack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Vector2 directionToEnemy = (enemy.transform.position - transform.position).normalized;
            Vector2 attackDirection = spriteTransform.localScale.x > 0 ? Vector2.right : Vector2.left;

            if (Vector2.Dot(directionToEnemy, attackDirection) > 0)
            {
                enemy.GetComponent<Enemy>()?.TakeDamage(attack);
            }
        }

        yield return new WaitForSeconds(1f);
        canMeleeAttack = true;
    }

    IEnumerator SpellCooldown()
    {
        yield return new WaitForSeconds(3f);
        canCastSpell = true;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Die");
        rb.linearVelocity = Vector2.zero;
        Debug.Log("Le joueur est mort !");
        // finaliser la mort du player
    }

    public void GainXP(int xp)
    {
        currentXP += xp;
        Debug.Log("XP gagnée : " + xp);

        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }
    
    private void LevelUp()
    {
        currentXP -= xpToNextLevel;
        currentLevel++;
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.5f);

        maxHealth = Mathf.RoundToInt(maxHealth * levelUpStatMultiplier);
        attack = Mathf.RoundToInt(attack * levelUpStatMultiplier);
        magic = Mathf.RoundToInt(magic * levelUpStatMultiplier);
        currentHealth = maxHealth;

        Debug.Log("Niveau UP ! Nouveau niveau : " + currentLevel);
    }
}