using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseBehaviour : EnemyMovementBehaviour
{
    
    EnemyPatrolBehaviour patrolBehaviour;
    bool hasPatrolBehaviour;
    
    protected override void EnemyMoveStateEnter(){
        hasPatrolBehaviour = false;
        if (patrolBehaviour == null) patrolBehaviour = GetComponent<EnemyPatrolBehaviour>();
        if (patrolBehaviour != null) hasPatrolBehaviour = true;

    }



    public override void EnemyStateUpdate(){
        
        Vector2 dir = (Vector2)(PlayerTransform.position - transform.position);
        EnemyMove(dir);


        if (!hasPatrolBehaviour) return;

        patrolBehaviour.PatrolCheck();
        
    }
}
