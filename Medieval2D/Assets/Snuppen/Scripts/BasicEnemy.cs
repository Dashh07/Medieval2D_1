using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;

public class BasicEnemy : EnemyStateLogic
{
     
    
    [SerializeField] protected float speed = 1;
    [SerializeField] float maxHealth = 100;
    protected float health;

    void ResetEnemyHealth(){
        health = maxHealth;
    }
    public float ReturnSpeed(){
        return speed;
    }
    
    void Start()
    {
        
        ChangeState<EnemyPatrolBehaviour>();
    }

    public void TakeDamage(float damage){
        health -= damage;
        if (health <= 0) EnemyDeath();
    }
    void EnemyDeath(){
        Destroy(gameObject);
    }
    
}
