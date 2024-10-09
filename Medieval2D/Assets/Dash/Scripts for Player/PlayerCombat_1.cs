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


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
        
    }

    void Attack()
    {

        if (Input.GetButtonDown("Fire1"))
        {


            animator.SetBool("isAttack", true);

        }
    }
  
    
    public void attack()
    {

        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange,enemyLayers );

        foreach (Collider2D enemy in hitenemies)
        {

            enemy.GetComponent<BasicEnemy>().TakeDamage(attackDamage);

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
