using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

abstract public class EnemyMovementBehaviour : EnemyState
{   
    static protected Transform PlayerTransform;
    [SerializeField] Rigidbody2D enemyRB;
    float speed;
    [SerializeField] protected bool isFlying;
    override public void EnemyStateEnter(){
        if (PlayerTransform == null) PlayerTransform = GameObject.Find("Player Knight").transform;
        if (enemyRB == null) enemyRB = GetComponent<Rigidbody2D>();
        speed = GetComponent<BasicEnemy>().ReturnSpeed();
        enemyRB.WakeUp();
        EnemyMoveStateEnter();
    }
    override public void EnemyStateExit(){
        enemyRB.velocity = new();
        enemyRB.Sleep();
    }
    protected void EnemyMove(Vector2 dir){
        SetRotation(dir);

        if (isFlying){
            //blah blah blah
            return;
        } 
        
        dir.y = 0;
        enemyRB.velocity = dir.normalized * speed + new Vector2(0, enemyRB.velocity.y);
        
    }

    protected void SetRotation(Vector2 dir){
        if (dir.x < 0){
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else if (dir.x > 0){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    protected abstract void EnemyMoveStateEnter();
}
