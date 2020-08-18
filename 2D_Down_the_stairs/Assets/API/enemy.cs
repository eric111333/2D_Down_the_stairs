using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public int maxHealth = 120;
    int currentHealth;
    private Animator ani;
    public GameObject gold;//生錢
    public GameObject potion;
    public float dropRate;
    public static int killer;

    void Start()
    {
        currentHealth = maxHealth;
        ani = GetComponent<Animator>();
        dropRate = Random.Range(0, 100);

    }
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Vector3 pos = new Vector3(transform.position.x + Random.Range(-0.1f, 0.1f), transform.position.y, 0);
        if (currentHealth<=0)
        {
            if(dropRate<=10)
            {
                Instantiate(potion, pos, Quaternion.identity);
            }
            GroundNum.bosskiller--;
            ani.SetTrigger("die");
            Instantiate(gold, pos, Quaternion.identity);
            Die();
        }
    }
    void Die()
    {
        Destroy(this.gameObject,0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
