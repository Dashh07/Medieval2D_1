using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFleeBehaviour : EnemyMovementBehaviour
{   

    [SerializeField] float fleeRange;
    Vector2 dir;
    
    public void SetFleeRange(float _fleeRange){
        fleeRange = _fleeRange;
    }
    
    protected override void EnemyMoveStateEnter(){
        
    }
    
    public override void EnemyStateUpdate(){
        FleeCheck();
        dir = (Vector2)(transform.position - PlayerTransform.position);
        EnemyMove(dir);
    }

    public void FleeCheck(){
        if (Vector2.Distance((Vector2)PlayerTransform.position, (Vector2)transform.position) < (0.9 * fleeRange)) enemyScript.ChangeState<EnemyFleeBehaviour>();
        if (Vector2.Distance((Vector2)PlayerTransform.position, (Vector2)transform.position) > (1.2 * fleeRange)) enemyScript.ChangeState<EnemyShootBehaviour>();
    }
}
