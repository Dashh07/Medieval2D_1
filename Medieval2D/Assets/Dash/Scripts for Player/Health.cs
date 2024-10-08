using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] UnityEvent died;
    public float maxHealth = 100;
    public float currentHealth;
    public Image healthbar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
       

    }  

    public void TakeDamage(float damage)
    {

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthbar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1);
        if (currentHealth == 0)
        {
                died.Invoke();

                gameObject.SetActive(false);


        }
    }
}
