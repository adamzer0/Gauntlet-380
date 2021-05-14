using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stairs : MonoBehaviour
{
    public string nextlevel = "Level_2";
    public int disabletimer = 3;
    private void Update()
    {
        disabletimer -= 1;
        //prevents warping through multiple levels at once.
        if (disabletimer <= 0)
        {
            gameObject.transform.tag = "Exit";
        }

    }
}
