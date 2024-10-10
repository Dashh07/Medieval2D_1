using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    Vector2 shotDirection;
    
    float maxProjectileSpeed;
    float projectileSpeed;
    float currentAngle;
    float projectileDrop = 0.5f;
    Vector3 rotateQuat;

    bool hasHitPlayer;

    int lifeTime;

    public void SetDirectionAndSpeed(Vector2 _shotDirection, float _projectileSpeed){
        
        shotDirection = _shotDirection;
        projectileSpeed = _projectileSpeed;
        maxProjectileSpeed = projectileSpeed;


        DetermineAim();
        
        
    }
    void DetermineAim(){
        float playerDistance = shotDirection.magnitude;
        currentAngle = Vector2.SignedAngle(Vector2.up, shotDirection);

        if (currentAngle > 0) playerDistance *= -1;
        playerDistance *= 1.5f;

        currentAngle += playerDistance;
        
        
   
    }
    void ProjectileBallistics(){
        if (Mathf.Abs(currentAngle) >= 180) return;
        if (currentAngle > 0) currentAngle += projectileDrop;
        if (currentAngle < 0) currentAngle -= projectileDrop;
        
    }
    private void FixedUpdate(){
        lifeTime++;
        if (lifeTime > 500) Destroy(gameObject);
        
        if (hasHitPlayer) return;

        ProjectileBallistics();

        transform.rotation = Quaternion.AngleAxis(currentAngle, new Vector3(0, 0, 1));

        transform.Translate(0, projectileSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (hasHitPlayer) return;
        if (other.CompareTag("Enemy")){
            return;
        }
        if (other.CompareTag("shield")){
            Destroy(gameObject);
            return;
        }
        
        if (other.CompareTag("Player")){
            other.GetComponent<Health>().TakeDamage(40);
            hasHitPlayer = true;
            transform.SetParent(other.transform);
            return;
        }
        Destroy(gameObject);
    }
}
