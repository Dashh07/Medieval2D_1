using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    AudioManager audioManager;

    [SerializeField] UnityEvent died;
    public float maxHealth = 100;
    public float currentHealth;
    public Image healthbar;
    public Animator animator;
    public bool isDead;
    int iFrames;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        healthbar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1);
        iFrames--;
    }  

    public void TakeDamage(float damage)
    {

        if (iFrames > 0) return;
        iFrames = 40;
        currentHealth -= damage;
        
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthbar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1);

        if(currentHealth > 0)
        {
            audioManager.PlaySFX(audioManager.GetHit);
            animator.SetBool("isHurt", true);
            animator.SetBool("isJumping", false);
        }


        if (currentHealth == 0)
        {
            animator.SetBool("isHurt", false);
            animator.SetBool("isJumping", false);
            audioManager.PlaySFX(audioManager.PlayerDeath);
            animator.SetBool("isDead", true);
                died.Invoke();
            isDead = true; 






        }
    }

  public void isHurt()
    {

        animator.SetBool("isHurt",false);


    }
}
