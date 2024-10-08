using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseBehaviour : EnemyMovementBehaviour
{
    
    EnemyPatrolBehaviour patrolBehaviour;
    bool hasPatrolBehaviour;
    
    protected override void EnemyMoveStateEnter(){
        if (patrolBehaviour == null) patrolBehaviour = GetComponent<EnemyPatrolBehaviour>();

        
        
    }

    public override void EnemyStateExit(){
        
    }

    public override void EnemyStateUpdate(){
        transform.rotation = new();
        Vector2 dir = (Vector2)(playerTransform.position - transform.position);
        EnemyMove(dir);

        if (patrolBehaviour == null) return;

        patrolBehaviour.PatrolCheck();
        
    }
}
