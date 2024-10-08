using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Chase_Player_Snup : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    Transform player;
    Rigidbody2D rb;
    FlipforBoss boss;
    Health playerHealth;
    int windUp;
    [SerializeField] int attackInterval;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        windUp = 0;
        player ??= GameObject.FindGameObjectWithTag("Player").transform;
        rb ??= animator.GetComponent<Rigidbody2D>();
        boss ??= animator.GetComponent<FlipforBoss>();
        playerHealth ??= player.GetComponent<Health>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerHealth.isDead)
        {
            return;
        }
        boss.LookAtPlayer();

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            windUp++;
            if (windUp >= attackInterval) animator.SetTrigger("Attack");

            return;
        }   
        windUp--;
        if (windUp < 0) windUp = 0;
        
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
            animator.ResetTrigger("Attack");
    }

}
