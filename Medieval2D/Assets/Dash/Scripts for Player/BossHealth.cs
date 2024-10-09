using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public Animator animator;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {


        currentHealth -= damage;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth > 0)
        {

            animator.SetBool("isHurt", true);

        }
        if (currentHealth == 0)
        {

            animator.SetBool("isDead", true);
            isDead = true;






        }
    }
    public void isHurt()
    {

        animator.SetBool("isHurt", false);


    }
}
