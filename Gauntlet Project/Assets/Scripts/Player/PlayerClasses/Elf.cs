using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : PlayerMove
{
    public override void Update()
    {
        if (Input.GetKey("i"))
        {
            myup = true;
        }
        if (Input.GetKey("k"))
        {
            mydown = true;
        }
        if (Input.GetKey("l"))
        {
            myright = true;
        }
        if (Input.GetKey("j"))
        {
            myleft = true;
        }
        if (Input.GetKeyDown("p"))
        {
            firing = true;
        }
        if (Input.GetKeyDown("u"))
        {
            usebomb = true;
        }
        if (Input.GetKeyDown("h"))
        {
            melee = true;
        }
        base.Update();
    }
}
