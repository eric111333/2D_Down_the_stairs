using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public int maxHealth = 40;
    int currentHealth;
    private Animator ani;

    void Start()
    {
        currentHealth = maxHealth;
        ani = GetComponent<Animator>();

    }
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth<=0)
        {
            ani.SetTrigger("die");
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
