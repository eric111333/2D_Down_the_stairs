using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform player;
    Animator ani;
    public float speed;
    public float moveSpeed;
    public float bossRange;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        print(player.transform.position);
        if(distToPlayer<bossRange)
        {
            chasePlayer();
        }
        else
        {
            stopPlayer();
        }
    }
    void chasePlayer()
    {
        if(transform.position.x  < player.transform.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
        }
    }
    void stopPlayer()
    {
        rb.velocity = new Vector2(0, 0);
    }
    /*private void FixedUpdate()
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2.MoveTowards(rb.position, target, speed);
    }*/

}
