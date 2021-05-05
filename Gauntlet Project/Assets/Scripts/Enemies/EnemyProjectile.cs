﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public float speed = 0.1f;
    //this projectile goes forward every frame by its speed.
    public void Update()
    {
        transform.Translate(transform.forward * speed);
    }
    //when it hits a wall it dissapates.
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}