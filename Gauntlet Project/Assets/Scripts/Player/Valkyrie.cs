using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valkyrie : PlayerMove
{

    // Update is called once per frame
    public override void Update()
    {
        if (Input.GetAxis("VerticalV") >= 0.5)
        {
            myup = true;
        }
        if (Input.GetAxis("VerticalV") >= 0.5)
        {
            mydown = true;
        }
        if (Input.GetAxis("HorizontalH") >= 0.5)
        {
            myright = true;
        }
        if (Input.GetAxis("HorizontalH") <= -0.5)
        {
            myleft = true;
        }
    }
}
