using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSelf : MonoBehaviour
{
    //this script simply makes something remove itself
    //after 2 ticks, giving everything a chance
    //to die to it.
    public float removedelay = 3;
    public int removedelaynodelta = 3;
    public GameObject myowner;
    //for bombs
    public int mypower = 1;
    void Update()
    {
        removedelay -= 1 * Time.deltaTime * 60;
        removedelaynodelta -= 1;
       
       
        if (removedelay <= 0 && removedelaynodelta <= 0)
        {
            Destroy(gameObject);
        }
    }
}
