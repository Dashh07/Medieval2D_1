using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat_1 : MonoBehaviour
{
    public Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {

        if (Input.GetButtonDown("Fire1"))
        {


            animator.SetBool("isAttack", true);
        }

        if (Input.GetButtonUp("Fire1"))
        {


            animator.SetBool("isAttack", false);
        }
    }

    
}
