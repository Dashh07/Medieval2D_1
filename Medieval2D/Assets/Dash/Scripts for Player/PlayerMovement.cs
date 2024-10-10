using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float horizontalInput;
    public float speed;
    public float jumpForce;
    public Animator animator;
    public bool facingRight = true;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

       
        if (horizontalInput > 0 && !facingRight)
        {

            Flip();


        }

        if (horizontalInput < 0 && facingRight)
        {

            Flip();



        }

        if (Input.GetButtonDown("Jump") && isGrounded())
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);

        }
        if (isGrounded() && rb.velocity.y < 0.01)
        {

            animator.SetBool("isJumping", false);
            

        }


    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        animator.SetFloat("Speed",Mathf.Abs(horizontalInput));
    }


    void Flip()
    {

        transform.Rotate(0f, 180f, 0f);

        facingRight = !facingRight;

    }

}
