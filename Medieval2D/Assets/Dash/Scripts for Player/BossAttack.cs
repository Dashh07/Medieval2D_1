using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float attackDamage = 30f;

    public Vector3 attackPoint;
    public float attackRange = 1f;
    public LayerMask player;

 

    public void Attack()
    {
        
        Vector3 pos = transform.position;
        pos += transform.right * attackPoint.x;
        pos += transform.up * attackPoint.y;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, player);

        if(colInfo != null)
        {
            if (!colInfo.gameObject.CompareTag("Player")) return;
            colInfo.GetComponent<Health>().TakeDamage(attackDamage);

        }


    }
    private void OnDrawGizmos()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackPoint.x;
        pos += transform.up * attackPoint.y;
        Gizmos.DrawWireSphere(pos, attackRange);
    }


    
}
