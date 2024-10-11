using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootBehaviour : EnemyMovementBehaviour
{
    EnemyPatrolBehaviour patrolBehaviour;
    EnemyFleeBehaviour fleeBehaviour;
    bool hasPatrolBehaviour;
    bool hasFleeBehaviour;
    Vector2 playerPosition;

    [SerializeField] GameObject Arrow;
    GameObject shotArrow;
    [SerializeField] float projectileSpeed = 0.2f;
    [SerializeField] int shootInterval = 100;
    int shootTimer;

    protected override void EnemyMoveStateEnter(){
        shootTimer = 0;
        hasPatrolBehaviour = false;
        hasFleeBehaviour = false;

        if(fleeBehaviour == null) fleeBehaviour = GetComponent<EnemyFleeBehaviour>();
        if (fleeBehaviour != null) hasFleeBehaviour = true;

        if (patrolBehaviour == null) patrolBehaviour = GetComponent<EnemyPatrolBehaviour>();
        if (patrolBehaviour != null) hasPatrolBehaviour = true;

        
    }

    public override void EnemyStateExit(){
        
    }

    public override void EnemyStateUpdate(){
        EnemyMove(new());
        
        
        TryShoot(GetPLayerDirection());
        //shotArrow = Instantiate(Arrow);
        //shotArrow.GetComponent<ProjectileScript>().SetDirection(dir);
        
        
    }

    Vector2 GetPLayerDirection(){
        Vector2 shootDir;
        
        playerPosition = (Vector2)PlayerTransform.position;
        shootDir = playerPosition - (Vector2)transform.position;

        SetRotation(shootDir);
        return shootDir;
    }

    void TryShoot(Vector2 dir){
        animator.SetBool("IsAttacking", true);
        shootTimer++;
        if (shootTimer < shootInterval) return;
        
        shootTimer = 0;
        
        ShootArrow(dir);

        CheckBehaviourChange();
    }

    void CheckBehaviourChange(){
        if (hasFleeBehaviour){
            fleeBehaviour.FleeCheck();
        }
        
        if (hasPatrolBehaviour){
            patrolBehaviour.PatrolCheck();
        }
        
    }
    void ShootArrow(Vector2 dir){
        
        float playerDistance = dir.magnitude;
        Vector2 shootPoint = (Vector2)transform.position;
        shootPoint.y -= 0.35f;

        shotArrow = Instantiate(Arrow, shootPoint, new());
        shotArrow.GetComponent<ProjectileScript>().SetDirectionAndSpeed(dir, projectileSpeed);
        animator.SetBool("IsAttacking", false);
    }
    

    
}
