using UnityEngine;
using System.Collections;
public class attack : MonoBehaviour
{
    
    private Animator aniPlayer;
    private SpriteRenderer sprPlayer;
    public Transform attackpoint;
    private AudioSource aud;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public AudioClip soundAttack;
    // Use this for initialization
    void Start()
    {
        aud = GetComponent<AudioSource>();
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
        //attackpoint.position = sprPlayer.transform.position + sprPlayer.transform.up * 0.12f;

    }

    private void Attack()
    {
        aniPlayer.SetTrigger("attack");
        aud.PlayOneShot(soundAttack); 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);



        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemy>().TakeDamage(attackDamage);

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