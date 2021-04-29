﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //new position and direction for movement
    public Vector3 newpos;
    public Vector3 neweuler;
    //you know what speed is
    public float speed = 0.1f;
    //direction you shoot in, set when you move
    private string shootdirection;
    //the projectile that the class shoots.
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        //basic setting up of rotation and movement;
        neweuler = transform.eulerAngles;
        newpos = transform.position;
        //this system creates a total of 12 raycasts, checking the top bottom and middle of the character for geometry. 
        //If it runs into anything that it can raycast hit, the player cannot move in said direction
        if (Input.GetKey("w"))
        {

            if (!Physics.Raycast(transform.position, (Vector3.forward), speed + 0.5f) && !Physics.Raycast(transform.position+ Vector3.right/2, (Vector3.forward), speed + 0.5f) && !Physics.Raycast(transform.position+ Vector3.left/2, (Vector3.forward), speed + 0.5f))
            {
                newpos.z += speed;
                neweuler.y = 0;
                shootdirection = "up";
            }
        }
        if (Input.GetKey("s"))
        {

            if (!Physics.Raycast(transform.position, (Vector3.back), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.right / 2, (Vector3.back), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.left / 2, (Vector3.back), speed + 0.5f))
            {
                newpos.z -= speed;
                neweuler.y = 180;
                shootdirection = "down";
            }
        }
        if (Input.GetKey("a"))
        {

            if (!Physics.Raycast(transform.position, (Vector3.left), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.forward / 2, (Vector3.left), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.back / 2, (Vector3.left), speed + 0.5f))
            {
                newpos.x -= speed;
                neweuler.y = 270;
                shootdirection = "left";
            }
        }
        if (Input.GetKey("d"))
        {

            if (!Physics.Raycast(transform.position, (Vector3.right), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.forward / 2, (Vector3.right), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.back / 2, (Vector3.right), speed + 0.5f))
            {
                newpos.x += speed;
                neweuler.y = 90;
                shootdirection = "right";
            }
        }
        //basic execution of movement and rotation
        transform.position = newpos;
        transform.eulerAngles = neweuler;
        //when F is held, the player will rapidly shoot based on their direction.
        //their direction is set whenever they hit a movement key.
        if (Input.GetKey("f"))
        {
            if (shootdirection == "up")
            {
                Instantiate(projectile, transform.position + Vector3.forward, transform.rotation);
            }
            if (shootdirection == "down")
            {
                Instantiate(projectile, transform.position + Vector3.back, transform.rotation);
            }
            if (shootdirection == "left")
            {
                Instantiate(projectile, transform.position + Vector3.left, transform.rotation);
            }
            if (shootdirection == "right")
            {
                Instantiate(projectile, transform.position + Vector3.right, transform.rotation);
            }
        }
    }
}