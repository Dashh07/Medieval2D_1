using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            Restart();


        }
    }

    public void Restart()
    {

        SceneManager.LoadScene("MarcusLevel");


    }
}
