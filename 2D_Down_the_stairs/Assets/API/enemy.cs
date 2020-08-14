using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public int maxHealth = 40;
    int currentHealth;
    public Text hpdam;
    
    void Start()
    {
        currentHealth = maxHealth;
        
    }
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hpdam.text = "" + damage;
        if (currentHealth<=0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(this.gameObject,2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
