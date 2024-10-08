using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;  
    public float maxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

   void Update()
    {
        if(health <= 0)
        {

            Destroy(gameObject);

        }
    }

}
