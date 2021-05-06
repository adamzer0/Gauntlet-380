using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSelf : MonoBehaviour
{
    //this script simply makes something remove itself
    //after 2 ticks, giving everything a chance
    //to die to it.
    public int removedelay = 3;
   
    void Update()
    {
        removedelay -= 1;
        if (removedelay <= 0)
        {
            Destroy(gameObject);
        }
    }
}
