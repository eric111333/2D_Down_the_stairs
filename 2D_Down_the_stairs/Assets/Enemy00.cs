using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy00 : enemy
{

    public static int Hp = 500;
    public static int HpMax = 500;
    private Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
        dropRate = Random.Range(0, 100);
    }
    public override void TakeDamage(int damage)
    {
        Hp -= damage;
        Vector3 pos = new Vector3(transform.position.x + Random.Range(-0.1f, 0.1f), transform.position.y, 0);
        ani.SetTrigger("hit");
        GameObject points = Instantiate(hitPrint, transform.position, Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + damage;
        if (Hp <= 0)
        {
            if (dropRate <= 10)
            {
                Instantiate(potion, pos, Quaternion.identity);
            }
            GroundNum.bosskiller--;
            ani.SetTrigger("die");
            Instantiate(gold, pos, Quaternion.identity);
            Die();
        }
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fireball")
        {
            Debug.Log("123");
            Hp -= attack.attackDamage * 2;
            Vector3 pos = new Vector3(transform.position.x + Random.Range(-0.1f, 0.1f), transform.position.y, 0);
            GameObject points = Instantiate(hitPrint, transform.position, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + attack.attackDamage * 2;
            if (Hp <= 0)
            {
                if (dropRate <= 10)
                {
                    Instantiate(potion, pos, Quaternion.identity);
                }
                GroundNum.bosskiller--;
                ani.SetTrigger("die");
                Instantiate(gold, pos, Quaternion.identity);
                Die();
                return;
            }
        }

    }



    void Die()
    {
        Destroy(this.gameObject, 0.5f);
    }
    void Update()
    {

    }
}
