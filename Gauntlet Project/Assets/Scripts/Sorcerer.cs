using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : BasicEnemy
{

    //this determines how long it has been
    private int invisible = 0;
    //this checks if it is invisible
    private int isinvis = 0;
    //this makes it invisible
    public Color c;
    //this sets how long it will be invisible for
    public int invisturn = 150;
    // Update is called once per frame
    public void Awake()
    {
        base.Awake();
        c = GetComponent<Renderer>().material.color;
    }
    public override void Update()
    {
        base.Update();
        //every frame invisible goes up by one.
        //if it hits a threshhold it will change
        //either to or from invisible based on
        //if it is currently invisible or not.
        invisible += 1;
        if (invisible >= invisturn && isinvis == 0)
        {
            c.a = 0.001f;
            isinvis = 1;
            GetComponent<Renderer>().material.color = c;
        }
        if (invisible >= invisturn*2 && isinvis == 1)
        {
            invisible = 0;
            c.a = 1;
            isinvis = 0;
            GetComponent<Renderer>().material.color = c;
        }

    }
}
