using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BasicEnemy : EnemyStateLogic
{
    
    [SerializeField] protected float speed = 1;
    public float ReturnSpeed(){
        return speed;
    }
    
    void Start()
    {
        ChangeState<EnemyPatrolBehaviour>();
    }
    
}
