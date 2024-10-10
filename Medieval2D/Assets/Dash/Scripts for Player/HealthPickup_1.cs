using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    Health playerHealth;

    public float healthBonus = 15f;
    // Start is called before the first frame update

    private void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;

        if (playerHealth.currentHealth < playerHealth.maxHealth)
        {

            
            playerHealth.currentHealth = playerHealth.currentHealth + healthBonus;
            Destroy(gameObject);


        }

    }

}
