using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyMovementBehaviour : EnemyState
{   
    static protected Transform playerTransform;
    [SerializeField] Rigidbody2D enemyRB;
    float speed;
    [SerializeField] protected bool isFlying;
    override public void EnemyStateEnter(){
        if (playerTransform == null) playerTransform = GameObject.Find("Player Knight").transform;
        if (enemyRB == null) enemyRB = GetComponent<Rigidbody2D>();
        speed = GetComponent<BasicEnemy>().ReturnSpeed();
        EnemyMoveStateEnter();
    }
    protected void EnemyMove(Vector2 dir){
        if (dir.x < 0){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if (dir.x > 0){
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        
        if (isFlying){

            return;
        } 
        
        dir.y = 0;
        enemyRB.velocity = dir.normalized * speed + new Vector2(0, enemyRB.velocity.y);
        
    }
    protected abstract void EnemyMoveStateEnter();
}
