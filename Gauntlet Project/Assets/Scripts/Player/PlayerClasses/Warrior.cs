using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerMove
{
   //WARRIOR USES WASD
    public override void Update()
    {
    
        if (Input.GetKey("w"))
        {
           myup = true;
         
        }
        if (Input.GetKey("s"))
        {
            mydown = true;
  
        }
        if (Input.GetKey("d"))
        {
   
            myright = true;
        }
        if (Input.GetKey("a"))
        {
            myleft = true;

        }
        if (Input.GetKeyDown("f"))
        {
            firing = true;
        }
        if (Input.GetKeyDown("q"))
        {
            usebomb = true;
        }
        if (Input.GetKeyDown("e"))
        {
            melee = true;
        }
       base.Update();
    }

}
