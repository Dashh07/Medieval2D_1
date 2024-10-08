using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolBehaviour : EnemyState
{
    public float speed = 1.0f;
    [SerializeField] PatrolPathScript patrolObjectScript;
    Vector3[] patrolPoints;
    int patrolTarget = 0;

    PatrolPathScript FindPatrolObject(){
        return transform.Find("PatrolPath").GetComponent<PatrolPathScript>();
    }

    public override void EnemyStateEnter(){
        if (patrolObjectScript == null){
            patrolObjectScript = FindPatrolObject();
        }
        patrolPoints = patrolObjectScript.ReturnPatrolPoints();
    }
    public override void EnemyStateExit()
    {
        
    }

    public override void EnemyStateUpdate()
    {
        Vector3 dir = (patrolPoints[patrolTarget] - transform.position).normalized;
        transform.Translate(dir * speed, Space.World);

        if (Vector3.Distance(transform.position, patrolPoints[patrolTarget]) <= speed){
            patrolTarget++;
            if (patrolTarget == patrolPoints.Length) patrolTarget = 0;
        }
    }

}
