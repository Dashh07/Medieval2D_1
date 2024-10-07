using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement1 : MonoBehaviour
{
    public float speed = 1.0f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = Patrol1.points[0];
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }




    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Patrol1.points.Length - 1)
        {
            wavepointIndex = -1;
            return;
        }
        wavepointIndex++;
        target = Patrol1.points[wavepointIndex];
    }

}
