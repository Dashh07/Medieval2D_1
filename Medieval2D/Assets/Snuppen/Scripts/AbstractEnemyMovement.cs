using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyMovementBehaviour : EnemyState
{   
    static protected Transform playerTransform;
    [SerializeField] Rigidbody2D enemyRB;
    float speed;
    protected bool isFlying;
    override public void EnemyStateEnter(){
        if (playerTransform == null) playerTransform = GameObject.Find("Player Knight").transform;
        if (enemyRB == null) enemyRB = GetComponent<Rigidbody2D>();
        speed = GetComponent<BasicEnemy>().ReturnSpeed();
        EnemyMoveStateEnter();
    }
    protected void EnemyMove(Vector2 dir){
        if (!isFlying) dir.y = 0;
        enemyRB.velocity = dir.normalized * speed;
    }
    protected abstract void EnemyMoveStateEnter();
}
