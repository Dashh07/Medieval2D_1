using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerfalltoDeath : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UnityEvent died;
    private float bottomBound = -10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomBound)
        {
            died.Invoke();
            



        }
    }
    }
