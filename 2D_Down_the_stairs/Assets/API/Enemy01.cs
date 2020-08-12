using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Enemy01 : enemy
{
    [Header("移動速度"), Range(0, 100)]
    public float speed = 10;
    private SpriteRenderer sprPlayer;
    private Animator ani;
    
    int E01Health;
    private void Move()
    {
        float y = Mathf.Sin(Time.time) * Random.Range(-15, 15) * Time.deltaTime;
        transform.Translate(0, y, 0);
        if (sprPlayer.flipX == false)
            transform.Translate(speed * 1 * Time.deltaTime, 0, 0);
        if (gameObject.transform.position.x >= 4)
            sprPlayer.flipX = true;
        if (sprPlayer.flipX == true)
            transform.Translate(speed * -1 * Time.deltaTime, 0, 0);
        if (gameObject.transform.position.x <= -4)
            sprPlayer.flipX = false;


    }
    private void attack()
    {
        if (gameObject.transform.position.x >= 3 ) //|| gameObject.transform.position.x <= -3
            ani.SetTrigger("attack");
    }
  
    public override void TakeDamage(int damage)
    {
        E01Health -= damage;
        ani.SetTrigger("hit");
        if (E01Health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(this.gameObject);
    }
    void Start()
    {
        sprPlayer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        Destroy(gameObject, 10);
        E01Health = maxHealth;
    }

    void Update()
    {
        Move();
        attack();
    }
}
