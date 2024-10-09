using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : BasicEnemy
{
    
    private void Start(){
        ResetEnemyHealth();
        ChangeState<EnemyShootBehaviour>();
    }
    public override void AttackingState(){
        ChangeState<EnemyShootBehaviour>();
    }
    
}
