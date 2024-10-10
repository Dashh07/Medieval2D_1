using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;

public class BasicEnemy : EnemyStateLogic
{

    [SerializeField] Animator animator;
    [SerializeField] protected float speed = 1;
    [SerializeField] float maxHealth = 100;
    protected float health;
    EnemyPatrolBehaviour enemyPPBehaviour;

    private void Awake()
    {
        animator ??= transform.Find("EnemySprite").GetComponent<Animator>(); 
    }

    protected void ResetEnemyHealth(){
        health = maxHealth;
    }
    public float ReturnSpeed(){
        animator.SetFloat("Speed", speed);
        return speed;
    }
    
    void Start()
    {
        ResetEnemyHealth();
        enemyPPBehaviour = GetComponent<EnemyPatrolBehaviour>();
        if (enemyPPBehaviour != null) {
            ChangeState<EnemyPatrolBehaviour>();
        } else {
            //poopers oopers
        }
    }

    public void TakeDamage(float damage){
        health -= damage;
        if (health <= 0) EnemyDeath();
        animator.SetTrigger("IsHit");
    }
    void EnemyDeath(){
        animator.SetTrigger("IsDead");
        Destroy(gameObject);
    }

    public virtual void AttackingState(){
        ChangeState<EnemyChaseBehaviour>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(30);
            animator.SetTrigger("IsAttacking");
        }
    }
    
}
