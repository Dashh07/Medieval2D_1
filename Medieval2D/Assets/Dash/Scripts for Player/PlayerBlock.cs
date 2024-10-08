using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    public Animator animator;
    [SerializeField] Collider2D shieldCollider;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Block();
    }

    void Block()
    {
        
        if (Input.GetButtonDown("Fire2"))
        {

            shieldCollider.enabled = true;

            animator.SetBool("isBlocking", true);

        }
    }

    public void endBlock()
    {

        animator.SetBool("isBlocking", false);
        shieldCollider.enabled = false;

    }

   

}
