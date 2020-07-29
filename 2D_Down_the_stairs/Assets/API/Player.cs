﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator aniPlayer;
    private SpriteRenderer sprPlayer;
    Rigidbody2D playerRigidbody2D;
    [Header("目前的水平速度")]
    public float speedX;
    [Header("目前的水平方向")]
    public float horizontalDirection;//數值會在 -1~1之間
    const string HORIZONTAL = "Horizontal";
    [Header("水平推力")]
    [Range(0, 150)]
    public float xForce;
    //目前垂直速度
    float speedY;
    [Header("最大水平速度")]
    public float maxSpeedX;
    [Header("垂直向上推力")]
    public float yForce;
    [Header("感應地板的距離")]
    [Range(0, 0.5f)]
    public float distance;
    [Header("偵測地板的射線起點")]
    public Transform groundCheck;
    [Header("地面圖層")]
    public LayerMask groundLayer;
    public bool grounded;

    public static bool isDead;
    [Header("血量")]
    public static float hp = 1000;
    public static float hpMax = 1000;
    private Image hpBar;

    public void ControlSpeed()
    {
        speedX = playerRigidbody2D.velocity.x;
        speedY = playerRigidbody2D.velocity.y;
        float newSpeedX = Mathf.Clamp(speedX, -maxSpeedX, maxSpeedX);
        playerRigidbody2D.velocity = new Vector2(newSpeedX, speedY);


    }

    public bool JumpKey
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }

    void TryJump()
    {
        if (IsGround && JumpKey)
        {
            playerRigidbody2D.AddForce(Vector2.up * yForce);
            aniPlayer.SetBool("jumping", true);
        }
    }

    //在玩家的底部射一條很短的射線 如果射線有打到地板圖層的話 代表正在踩著地板
    bool IsGround
    {
        get
        {
            Vector2 start = groundCheck.position;
            Vector2 end = new Vector2(start.x, start.y - distance);

            Debug.DrawLine(start, end, Color.blue);
            grounded = Physics2D.Linecast(start, end, groundLayer);
            aniPlayer.SetBool("jumping", false);
            return grounded;
        }
    }

    void Start()
    {
        isDead = false;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        sprPlayer = GetComponent<SpriteRenderer>();
        aniPlayer = GetComponent<Animator>();
        hpBar = GameObject.Find("血條").GetComponent<Image>();
        hp = hpMax;

    }

    /// <summary>水平移動</summary>
    void MovementX()
    {
        horizontalDirection = Input.GetAxis(HORIZONTAL);
        playerRigidbody2D.AddForce(new Vector2(xForce * horizontalDirection, 0));
        aniPlayer.SetFloat("speed", Mathf.Abs(horizontalDirection));

        if (Input.GetKeyDown(KeyCode.A))
        {
            sprPlayer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            sprPlayer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sprPlayer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            sprPlayer.flipX = false;
        }
    }

    void Update()
    {
        MovementX();
        ControlSpeed();
        TryJump();
        //speedX = playerRigidbody2D.velocity.x;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;

        if (collision.tag == "陷阱")
        {
            hp -= 20;
            hpBar.fillAmount = hp / hpMax;
            aniPlayer.SetTrigger("hurt");

            if (hp <= 0) Dead();
        }
        if (collision.tag == "敵人")
        {
            hp -= 30;
            hpBar.fillAmount = hp / hpMax;
            aniPlayer.SetTrigger("hurt");

            if (hp <= 0) Dead();
        }
        if (collision.tag == "洞")
        {
            hp -= 10000;
            hpBar.fillAmount = hp / hpMax;
            aniPlayer.SetTrigger("hurt");

            if (hp <= 0) Dead();
        }
    }
    public void Dead()
    {
        aniPlayer.SetTrigger("dead");
        this.enabled = false;
        isDead = true;
        //gm.GameOver();
        print(1);


    }
}
