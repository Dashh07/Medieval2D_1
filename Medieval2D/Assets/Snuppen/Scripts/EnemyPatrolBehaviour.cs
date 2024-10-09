using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolBehaviour : EnemyMovementBehaviour
{
    [SerializeField] PatrolPathScript patrolObjectScript;
    [SerializeField] Vector2[] patrolPoints;
    int patrolTarget = 0;
    int tempPatrolTarget = 0;
    float largestPPDistance;
    float playerPPDistance;
    float tempPlayerPPDistance;
    
    

    PatrolPathScript FindPatrolObject(){
        return transform.Find("PatrolPath").GetComponent<PatrolPathScript>();
    }

    protected override void EnemyMoveStateEnter(){
        if (patrolPoints.Length == 0) FetchPP();

    }

    void FetchPP(){
        if (patrolObjectScript == null) patrolObjectScript = FindPatrolObject();
        patrolPoints = patrolObjectScript.ReturnPPs();

        largestPPDistance = 0;

        foreach (Vector2 pp1 in patrolPoints){
            foreach (Vector2 pp2 in patrolPoints){
                if (Vector2.Distance(pp1, pp2) > largestPPDistance) largestPPDistance = Vector2.Distance(pp1, pp2);
            }
        }
        Debug.Log(largestPPDistance);
    }

    public float ReturnBigPPDistance(){
        return largestPPDistance;
    }

    public override void EnemyStateExit()
    {
        
    }

    public override void EnemyStateUpdate()
    {
        ChaseCheck();
        transform.rotation = new();
        
        Vector2 dir = patrolPoints[patrolTarget] - (Vector2)transform.position;
        if (!isFlying) dir.y = 0;

        EnemyMove(dir);

        PatrolPointCheck();
    }
    void PatrolPointCheck(){
        //Checks only the x position if the enemy isn't flying. This way they won't get stuck trying to reach a patrolPoints[] in the air 
        if (!isFlying){
            if (Mathf.Abs(transform.position.x - patrolPoints[patrolTarget].x) < 0.1f){
                ChangePatrolTarget();
            }
            return;
        }

        if (Vector2.Distance((Vector2)transform.position, patrolPoints[patrolTarget]) < 0.1f){
            ChangePatrolTarget();
        }
    }

    void ChangePatrolTarget(){
        patrolTarget++;
        if (patrolTarget == patrolPoints.Length) patrolTarget = 0;
    }

    void ChaseCheck(){
        playerPPDistance = 0;
        //Checks the distances between the player and each patrol point, and compares the longest of those
        //to the longest distance between each patrol point, making the enemy chase only if...

        //If the player is closer to all patrol points than they are to eachother!!!
        foreach (Vector2 pp in patrolPoints){
            tempPlayerPPDistance = Vector2.Distance((Vector2)playerTransform.position, pp);

            if (tempPlayerPPDistance > playerPPDistance) playerPPDistance = tempPlayerPPDistance;
        }
        if (playerPPDistance < largestPPDistance) GetComponent<BasicEnemy>().ChangeState<EnemyChaseBehaviour>();
        
    }
    public void PatrolCheck(){
        playerPPDistance = 0;
        
        //Same thing here, only reversed! If the player is further away from any patrol point than they are to eachother,
        //the enemy starts patrolling again.
        foreach (Vector2 pp in patrolPoints){
            tempPlayerPPDistance = Vector2.Distance((Vector2)playerTransform.position, pp);

            if (tempPlayerPPDistance > playerPPDistance) playerPPDistance = tempPlayerPPDistance;
        
        }
        
        if (playerPPDistance > largestPPDistance){
            ChangeToPatrolMode();
        }
    }
    void ChangeToPatrolMode(){
        GetComponent<BasicEnemy>().ChangeState<EnemyPatrolBehaviour>();
        
        //Changes the patrol target to the one closest to the player, eliminating possibility of making enemies 
        //go back and forth when entering and exiting chase range repeatedly        
        playerPPDistance = largestPPDistance;

        for (int i = 0; i < patrolPoints.Length; i++){
            Debug.Log(i);
            tempPlayerPPDistance = Vector2.Distance(patrolPoints[i], (Vector2)playerTransform.position);

            if (tempPlayerPPDistance < playerPPDistance){
                playerPPDistance = tempPlayerPPDistance;
                tempPatrolTarget = i;
            }            
        }

        patrolTarget = tempPatrolTarget;

    }
}