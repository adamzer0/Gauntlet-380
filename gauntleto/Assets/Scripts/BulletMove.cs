﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    //speed
    public float speed = 0.5f;
    //how long the projectile exists for.
    public int lifespan = 30;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed);
        //lifespan goes down by 1 every frame and at 0 causes the projectile to dissapate;
        lifespan -= 1;
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        //destroy self upon hitting a wall.
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}