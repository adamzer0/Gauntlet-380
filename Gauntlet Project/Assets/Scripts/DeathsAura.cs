using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathsAura : MonoBehaviour
{
    private int healthDrained=0;
    private int drainMax = 100;
    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag =="Player")
        {

            if(healthDrained <=drainMax)
            {
                healthDrained += 1; 
            }
            else
            {
                Debug.Log("drained");
                return; 
            }
        }
    }
}
