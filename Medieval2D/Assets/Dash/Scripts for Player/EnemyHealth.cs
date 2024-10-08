using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    int currentHealth;
    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        currentHealth -= damage;

       

       

        if (currentHealth <= 0)
        {

            Die();

        }


    }

    void Die()
    {



        
        isDead = true;


        //Disable Enemy


        Destroy(gameObject);



    }

}
