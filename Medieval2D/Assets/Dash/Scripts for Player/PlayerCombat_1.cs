using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat_1 : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackDamage = 30;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            audioManager.PlaySFX(audioManager.Attack);
            animator.SetBool("isAttack", true);

        }
        
    }
  
    
    public void attack()
    {
        EnemyHealth enemyHealth;
        BasicEnemy basicEnemy;
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange,enemyLayers );

        foreach (Collider2D enemy in hitenemies)
        {
            basicEnemy = null;
            enemyHealth = null;

            basicEnemy = enemy.GetComponent<BasicEnemy>();
            enemyHealth = enemy.GetComponent<EnemyHealth>();

            if (enemyHealth != null) enemyHealth.TakeDamage(attackDamage);
            if (basicEnemy != null) basicEnemy.TakeDamage(attackDamage);
        }

    }
    
    
    
    public void endAttack()
    {

        animator.SetBool("isAttack", false);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }

}
