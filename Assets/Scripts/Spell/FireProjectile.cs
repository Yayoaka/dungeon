using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public GameObject spellPrefab;
    public Transform spellSpawnPoint;
    public float spellSpeed = 10f;
    public float spellRange = 5f;
    public LayerMask enemyLayers;

    private PlayerController PlayerController;

    public void CastSpell()
    {
        GameObject spell = Instantiate(spellPrefab, spellSpawnPoint.position, Quaternion.identity);
        Rigidbody2D rbSpell = spell.GetComponent<Rigidbody2D>();

        Vector2 spellDirection = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        rbSpell.linearVelocity = spellDirection * spellSpeed;

        RaycastHit2D[] hits = Physics2D.RaycastAll(spellSpawnPoint.position, spellDirection, spellRange, enemyLayers);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null)
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(PlayerController.magic);
                }
            }
        }
        
        Destroy(spell, spellRange / spellSpeed);
    }
}