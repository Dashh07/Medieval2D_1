using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShieldCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shieldCollider;

    void Start()
    {
        shieldCollider = GetComponent<GameObject>();
        shieldCollider.SetActive(false); // Start disabled
    }

    public void EnableCollider()
    {
        shieldCollider.SetActive(true);
    }

    public void DisableCollider()
    {
        shieldCollider.SetActive(false);
    }

}
