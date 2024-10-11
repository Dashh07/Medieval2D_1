using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack_Snup : StateMachineBehaviour
{   
    BossScript boss;
    Transform playerTransform;
    Health playerHealth;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        playerHealth ??= GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        boss ??= animator.GetComponent<BossScript>();
        playerTransform ??= playerHealth.transform;
        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        //if (playerHealth.isDead) animator.SetBool("playerDead", true);

        if (animator.transform.position.x - playerTransform.position.x < 0){
            boss.facingLeft = false;
        } else {
            boss.facingLeft = true;
        }

        animator.SetBool("attackPlayer", false);
        animator.SetBool("dontAttackPlayer", true);
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        
    }

    
    

    public void Attack()
    {
        
        


    }
   

    
}



