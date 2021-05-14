using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        //basic "press R to reset"
        if (Input.GetKeyDown("r"))
            {
            SceneManager.LoadScene("Level_0");
        }
    }
}
