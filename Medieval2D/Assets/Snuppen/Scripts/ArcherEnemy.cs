using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : BasicEnemy
{
    
    
    public override void AttackingState(){
        ChangeState<EnemyShootBehaviour>();
    }
    
}
