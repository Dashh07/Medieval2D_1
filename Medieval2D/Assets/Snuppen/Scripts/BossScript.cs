using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{   
    public Vector2 homePosition;
    public bool facingLeft;
    [SerializeField] public Rigidbody2D bossRB;

    [SerializeField] public float chaseRange;
    [SerializeField] public float speed = 1;
    [SerializeField] float maxHealth = 100;
    protected float health;

    void Start(){
        bossRB = GetComponent<Rigidbody2D>();
        homePosition = transform.position;
        health = maxHealth;
        
    }
    void FixedUpdate(){
        if (!facingLeft){
            transform.rotation = Quaternion.Euler(0, 180, 0);
            
        } else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void BossMove(Vector2 dir){
        if (dir.x > 0){ 
            facingLeft = false;
        }
        if (dir.x < 0){
            facingLeft = true;
        }

        bossRB.velocity = dir.normalized * speed + new Vector2(0, bossRB.velocity.y);
    }
    

    
}

