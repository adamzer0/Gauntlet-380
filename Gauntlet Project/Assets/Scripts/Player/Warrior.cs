using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerMove
{
   
    public override void Update()
    {
    
        if (Input.GetKey("w"))
        {
           myup = true;
            Debug.Log("warriod update W");
        }
        if (Input.GetKey("s"))
        {
            mydown = true;
            Debug.Log("warriod update S");
        }
        if (Input.GetKey("d"))
        {
            Debug.Log("warriod update D");
            myright = true;
        }
        if (Input.GetKey("a"))
        {
            myleft = true;
            Debug.Log("warriod update A");
        }
        if (Input.GetKeyDown("f"))
        {
            firing = true;
        }
        if (Input.GetKeyDown("q"))
        {
            usebomb = true;
        }
        if (Input.GetKeyDown("x"))
        {
            melee = true;
        }
       base.Update();
    }

}
