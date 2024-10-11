using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Idle_Snup : StateMachineBehaviour
{   
    Vector2 homePosition;
    Transform playerTransform;
    float chaseRange;
    float attackRange;
    BossScript bossScript;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        playerTransform ??= GameObject.FindGameObjectWithTag("Player").transform;

        Vector2 playerVec2, bossVec2;
        playerVec2 = (Vector2)playerTransform.position;
        bossVec2 = (Vector2)animator.transform.position;

        if (Vector2.Distance(playerVec2, bossVec2) < attackRange) animator.SetBool("attackPlayer", true);

        BossScript bossScript = animator.GetComponent<BossScript>();

        homePosition = bossScript.homePosition;
        chaseRange = bossScript.chaseRange;
        attackRange = bossScript.attackRange;

        chaseRange *= 0.9f;

        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        Vector2 playerVec2, bossVec2;
        playerVec2 = (Vector2)playerTransform.position;
        bossVec2 = (Vector2)animator.transform.position;

        if (Vector2.Distance(playerVec2, bossVec2) < attackRange) animator.SetBool("attackPlayer", true);
        if (Vector2.Distance(playerVec2, homePosition) < chaseRange) animator.SetBool("playerEnteredRange", true);
        if (Vector2.Distance(bossVec2, homePosition) > chaseRange) animator.SetBool("returnHome", true);
        
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        animator.SetBool("gotHome", false);
    }
}
