using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class PatrolPathScript : MonoBehaviour
{

    //Saves patrol point's positions at start instead of their transforms, allowing parenting of paths to enemies
    Vector2[] patrolPoints;
    
    void Start()
    {
        
        patrolPoints = new Vector2[transform.childCount];
        Transform childTransform;

        for (int i = 0; i < patrolPoints.Length; i++)
        {
            childTransform = transform.GetChild(i).transform;
            patrolPoints[i] = childTransform.position;
        }
    }
    public Vector2[] ReturnPPs(){
        return patrolPoints;
    }

}
