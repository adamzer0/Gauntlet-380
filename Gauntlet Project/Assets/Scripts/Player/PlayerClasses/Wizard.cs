using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : PlayerMove
{
    //WIZARD USES ARROW KEYS

    
    public override void Update()
    {
       
        if (Input.GetKey(KeyCode.UpArrow))
        {
            myup = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            mydown = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myright = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myleft = true;
        }
        if (Input.GetKeyDown("space"))
        {
            firing = true;
        }
        if (Input.GetKeyDown("x"))
        {
            usebomb = true;
        }
        if (Input.GetKeyDown("z"))
        {
            melee = true;
        }
        base.Update();
    }
   
}  
