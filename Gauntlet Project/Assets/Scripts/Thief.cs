using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : BasicEnemy
{
    public bool stole = false;

    private void Update()
    {
       if(health<=0)
        {
            //instantiate pickup
            //random val for chest amount

            // if player has boms instantiate those
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            player.GetComponent<PlayerMove>().health -= 10; 
            //reverse direction
            //steal object
      }

    }
}
