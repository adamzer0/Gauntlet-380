using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valkyrie : PlayerMove
{

     public override void Update()
   {
    
       if (Input.GetAxis("Horizontal") == 1)
       {
            myright = true;    
        }
        if (Input.GetAxis("Horizontal") ==-1)
        {
            myleft = true;
        }
        if (Input.GetAxis("Vertical") ==1)
        {
            myup = true;
        }
        if (Input.GetAxis("Vertical") ==-1)
        {
            mydown = true;
        }
        if (Input.GetButtonDown("AButton"))
        {
            firing = true; 
        }
        if (Input.GetButtonDown("XButton"))
        {
            melee = true;
        }
        if (Input.GetButtonDown("BButton"))
        {
            usebomb = true;
        }
        base.Update();
   }
}
