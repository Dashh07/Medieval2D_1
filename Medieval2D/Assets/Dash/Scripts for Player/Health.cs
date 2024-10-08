using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public Image healthbar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthbar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1);
    }

    public void TakeDamage(float damage)
    {

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth == 0)
        {

            Destroy(gameObject);



        }
    }
}
