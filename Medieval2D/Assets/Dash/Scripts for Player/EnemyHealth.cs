using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UnityEvent died;
    public float health;  
    public float maxHealth = 100;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

   void Update()
    {


        if (health <= 0)
        {

            animator.SetBool("isDead", true);
           died.Invoke();

           






        }
    }

}
