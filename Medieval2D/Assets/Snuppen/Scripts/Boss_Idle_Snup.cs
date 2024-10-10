using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Idle_Snup : StateMachineBehaviour
{   

    Vector2 homePosition;
    float chaseRange;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        if (homePosition == null) Debug.Log("poop");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){

    }
}
