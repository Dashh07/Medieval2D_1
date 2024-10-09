using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    bool playerHere = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHere = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHere = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!playerHere)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Sample");
        }
    }
}
