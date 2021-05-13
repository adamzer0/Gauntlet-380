using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : BasicEnemy
{
    public override void OnTriggerEnter(Collider other)
    {
        //ghosts die when they hit the player
        if(other.tag=="Player")
        {
            Destroy(this.gameObject);
        }
        base.OnTriggerEnter(other);
        Debug.Log("ghostlogging");
    }

}
