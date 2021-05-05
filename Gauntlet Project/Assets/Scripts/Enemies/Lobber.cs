﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobber : BasicEnemy
{
    private int shootdelay = 0;
    public int shootdelaymax = 50;
    public GameObject lobberprojectile;
   
  

    // Update is called once per frame
    public override void Update()
    {
        //every frame delay goes down by one
        //if delay is 0, then it will create
        //a projectile and reset the delay.
        shootdelay -= 1;
        if (shootdelay <= 0)
        {
            Instantiate(lobberprojectile, transform.position, transform.rotation);
            shootdelay = shootdelaymax;
        }
        base.Update();
    }
}