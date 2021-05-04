using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathsAura : BasicEnemy
{
    public int healthDrained=0;

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag =="Player")
        {

            if(healthDrained <100)
            {
                
                healthDrained += 1; 
            }
            if(healthDrained >=100)
            {
                Debug.Log("drained");
                transform.gameObject.tag = "Drained";
                return; 
            }
        }
    }
}
