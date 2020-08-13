using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int maxHealth = 40;
    int currentHealth;
    
    
    void Start()
    {
        currentHealth = maxHealth;
        
    }
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth<=0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
