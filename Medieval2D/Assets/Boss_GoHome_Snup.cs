using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_GoHome_Snup : StateMachineBehaviour
{   
    Vector2 homePosition;
    BossScript bossScript;
    Transform playerTransform;
    float chaseRange;
    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        playerTransform ??= GameObject.FindGameObjectWithTag("Player").transform;
        
        bossScript = animator.GetComponent<BossScript>();
        
        homePosition = bossScript.homePosition;

        chaseRange = bossScript.chaseRange;
        chaseRange *= 1.1f;
        
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        Vector2 playerVec2, bossVec2, dir;
        playerVec2 = (Vector2)playerTransform.position;
        bossVec2 = (Vector2)animator.transform.position;

        dir = homePosition - bossVec2;
        dir.y = 0;
        
        bossScript.BossMove(dir);

        if (Vector2.Distance(playerVec2, homePosition) < chaseRange) animator.SetBool("playerEnteredRange", true);
        if (Vector2.Distance(bossVec2, homePosition) < 1f) animator.SetBool("gotHome", true);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        animator.SetBool("returnHome", false);
    }

}
