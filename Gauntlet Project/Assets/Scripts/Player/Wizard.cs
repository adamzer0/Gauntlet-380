using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : PlayerMove
{

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
        if (Input.GetKey("g"))
        {
            firing = true;
        }
        base.Update();
    }

}
