using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceX;
    public static bool isDead;
    Rigidbody2D playerRigidBody2D;
    readonly float toleft = -1;
    readonly float toright = 1;
    readonly float stop = 0;
    float directionX;

    void Start()
    {
        isDead = false;
        playerRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            directionX = toleft;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            directionX = toright;
        }
        else
        {
            directionX = stop;
        }
        Vector2 newDirection = new Vector2(directionX, 0);
        playerRigidBody2D.AddForce(newDirection * forceX);
    }
}
