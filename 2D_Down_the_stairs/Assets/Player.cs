using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Player : MonoBehaviour
{

    private Animator aniPlayer;
    private SpriteRenderer sprPlayer; 
    public float forceX;
    public static bool isDead;
    Rigidbody2D playerRigidBody2D;
    readonly float toleft = -1;
    readonly float toright = 1;
    readonly float stop = 0;
    private float hp = 100;
    private float hpMax;
    private Image hpBar;
    private bool dead;
    private GameManager gm;
    float directionX;
    float directionY;
    [Header("移動速度"), Range(0, 100)]
    public float speed = 10;
    [Header("垂直向上推力")]
    Rigidbody2D playerRigidbody2D;
    public float yForce;
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
        }
    }
    [Header("感應地板的距離")]
    [Range(0, 1f)]
    public float distance;

    [Header("偵測地板的射線起點")]
    public Transform groundCheck;

    [Header("地面圖層")]
    public LayerMask groundLayer;

    public bool grounded;

    bool IsGround
    {
        get
        {
            Vector2 start = groundCheck.position;
            Vector2 end = new Vector2(start.x, start.y - distance);

            Debug.DrawLine(start, end, Color.blue);
            grounded = Physics2D.Linecast(start, end, groundLayer);
            return grounded;
        }
    }
    public void Dead()
    {
        //aniPlayer.SetTrigger("dead");
        this.enabled = false;
        isDead = true;
        //gm.GameOver();

    }
    void Start()
    {
        isDead = false;
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        sprPlayer = GetComponent<SpriteRenderer>();
        aniPlayer = GetComponent<Animator>();
        hpBar = GameObject.Find("血條").GetComponent<Image>();
        gm = FindObjectOfType<GameManager>();

        hpMax = hp;
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");

        transform.Translate(speed * h * Time.deltaTime, 0, 0);

        aniPlayer.SetBool("run", h != 0);
        ///    //AD左右鍵翻轉
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

        /*if (Input.GetKey(KeyCode.UpArrow))
        {
             directionY = toleft;
        }
        else
        {
            directionY = stop;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            directionX = toleft;
            aniPlayer.SetTrigger("run");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            directionX = toright;
            aniPlayer.SetTrigger("run");
        }
        else
        {
            directionX = stop;
        }
        Vector2 newDirection = new Vector2(directionX, directionY);
        playerRigidBody2D.AddForce(newDirection * forceX);
        */
        Move();
        TryJump();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dead) return;

        if (collision.tag == "陷阱")
        {
            hp -= 20;
            hpBar.fillAmount = hp / hpMax;
            //aniPlayer.SetTrigger("hurt");

            if (hp <= 0) Dead();
        }

        //Destroy(collision.gameObject);
    }

}
