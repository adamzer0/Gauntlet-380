using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobberProjectile : EnemyProjectile
{
    //this projectile does not disappear when it hits a wall
    public override void OnTriggerEnter(Collider other)
    {
        //base.OnTriggerEnter(other);
    }

}