using UnityEngine;
using System.Collections;
public class attack : MonoBehaviour
{
    
    private Animator aniPlayer;
    private SpriteRenderer sprPlayer;
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

    // Use this for initialization
    void Start()
    {
        sprPlayer = GetComponent<SpriteRenderer>();
        aniPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)|| Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
        
    }

    private void Attack()
    {
        aniPlayer.SetTrigger("attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);



        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemy>().TakeDamage(attackDamage);
            enemy.GetComponent<Enemy01>().TakeDamage(attackDamage);
        }

    }
    private void OnDrawGizmosSelected()
    {
        //if (sprPlayer.flipX) attackpoint.position = new Vector3(0.12f, 0, 0);
        //if (sprPlayer.flipX == false) attackpoint.position = new Vector3(-0.12f, 0, 0);
        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}