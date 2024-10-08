using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyArcher : MonoBehaviour
{
    private Transform target;
    public float speed = 1.0f;
    private Transform walkingTarget;
    private int wavepointIndex = 0;
    public float Range = 1f;
    public float archerFireRate = 1f;
    //private float archerfireCountdown = 0f;
    public float idleCountdown = 5f;

    public string playerTag = "Player";

    public GameObject arrowPrefab;
    public Transform firepoint;
    public bool IsAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("lol");
        walkingTarget = Patrol1.points[0];
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;
        foreach(GameObject player in players)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                nearestPlayer = player;
            }
        }
        if (nearestPlayer != null && shortestDistance <= Range)
        {
            target = nearestPlayer.transform;
            IsAttacking = true;
        }
        else
        {
            target = null;
            IsAttacking = false;
            Debug.Log(idleCountdown + "text");
            Passive();

        }

    }
    void Passive()
    {
        if (idleCountdown <= 0)
        {
            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (Vector2.Distance(transform.position, target.position) <= 0.4f)
            {
                GetNextWaypoint();
            }
        }
        idleCountdown =- 1f;
        Debug.Log(idleCountdown + "text");
    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Patrol1.points.Length - 1)
        {
            wavepointIndex = -1;
            return;
        }
        wavepointIndex++;
        idleCountdown++;
        walkingTarget = Patrol1.points[wavepointIndex];
    }
    
}
