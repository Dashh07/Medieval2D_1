using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : BasicEnemy
{
    
    private void Start(){
        ResetEnemyHealth();
        ChangeState<EnemyPatrolBehaviour>();
    }
    public override void AttackingState(){
        ChangeState<EnemyShootBehaviour>();
    }
    
}
