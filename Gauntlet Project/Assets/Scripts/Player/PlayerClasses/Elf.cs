using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : PlayerMove
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
        if (Input.GetKeyDown("g"))
        {
            firing = true;
        }
        if (Input.GetKeyDown("r"))
        {
            usebomb = true;
        }
        if (Input.GetKeyDown("t"))
        {
            melee = true;
        }
        base.Update();
    }
}
