using UnityEngine;
using System.Collections;
public class attack : MonoBehaviour
{
    
    private Animator aniPlayer;
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

    // Use this for initialization
    void Start()
    {

        aniPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
        
    }

    private void Attack()
    {
        aniPlayer.SetTrigger("attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemy>().TakeDamage(attackDamage);
        }

    }
    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}