using System.Collections;
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

    public int health = 600;
    public int score = 0;
    public int bombs = 0;
    public int keys = 0;
    public int storage = 10;
    // Update is called once per frame
    //these are used to give characters unique inputs
    public bool myup;
    public bool mydown;
    public bool myleft;
    public bool myright;
    public bool firing;

    public bool hasBomb=false;
    public bool hasKey=false;

    public virtual void Update()
    {
        //basic setting up of rotation and movement;
        neweuler = transform.eulerAngles;
        newpos = transform.position;
        //this system creates a total of 12 raycasts, checking the top bottom and middle of the character for geometry. 
        //If it runs into anything that it can raycast hit, the player cannot move in said direction
        //as the player can attack through corner gaps, the player can face a wall, just not move into said wall.
        if (myup)
        {
            shootdirection = "up";
            neweuler.y = 0;
            if (!Physics.Raycast(transform.position, (Vector3.forward), speed + 0.5f) && !Physics.Raycast(transform.position+ Vector3.right/2, (Vector3.forward), speed + 0.5f) && !Physics.Raycast(transform.position+ Vector3.left/2, (Vector3.forward), speed + 0.5f))
            {
                newpos.z += speed;


            }
        }
        if (mydown)
        {
            neweuler.y = 180;
            shootdirection = "down";
            if (!Physics.Raycast(transform.position, (Vector3.back), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.right / 2, (Vector3.back), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.left / 2, (Vector3.back), speed + 0.5f))
            {
                newpos.z -= speed;

            }
        }
        if (myleft)
        {
            neweuler.y = 270;
            shootdirection = "left";
            if (!Physics.Raycast(transform.position, (Vector3.left), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.forward / 2, (Vector3.left), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.back / 2, (Vector3.left), speed + 0.5f))
            {
                newpos.x -= speed;

                if (myup)
                {
                    shootdirection = "uleft";
                    neweuler.y = 315;
                }
                if (mydown)
                {
                    shootdirection = "dleft";
                    neweuler.y = 235;
                }
            }
        }
        if (myright)
        {
            neweuler.y = 90;
            shootdirection = "right";
            if (!Physics.Raycast(transform.position, (Vector3.right), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.forward / 2, (Vector3.right), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.back / 2, (Vector3.right), speed + 0.5f))
            {
                newpos.x += speed;

                if (myup)
                {
                    shootdirection = "uright";
                    neweuler.y = 45;
                }
                if (mydown)
                {
                    shootdirection = "dright";
                    neweuler.y = 135;
                }

            }
        }
        //basic execution of movement and rotation
        transform.position = newpos;
        transform.eulerAngles = neweuler;
        //when F is held, the player will rapidly shoot based on their direction.
        //their direction is set whenever they hit a movement key.
        if (firing)
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
            if (shootdirection == "uright")
            {
                Instantiate(projectile, transform.position + Vector3.right + Vector3.forward, transform.rotation);
            }
            if (shootdirection == "dright")
            {
                Instantiate(projectile, transform.position + Vector3.right + Vector3.back, transform.rotation);
            }
            if (shootdirection == "uleft")
            {
                Instantiate(projectile, transform.position + Vector3.left + Vector3.forward, transform.rotation);
            }
            if (shootdirection == "dleft")
            {
                Instantiate(projectile, transform.position + Vector3.left + Vector3.down, transform.rotation);
            }
        }
        myup = false;
        mydown = false;
        myleft = false;
        myright = false;
        firing = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        //when a pickup is picked up, it will be given tothe player.
        //using the pickup's code it can be a bomb key chest or food.
        //based on that you will heal or gain score/items.
        if (other.gameObject.tag == "Pickup")
        {
            var picktype = other.gameObject.GetComponent<Pickup>();
            if (picktype.type == "Food")
            {
                health += picktype.amount;
                Destroy(other.gameObject);
            }
            if (picktype.type == "Chest")
            {
                score += picktype.amount;
                Destroy(other.gameObject);
            }
            //bombs and keys may only be picked up if you have room.
            if (storage >= 1)
            {
                if (picktype.type == "Bomb")
                {
                    storage -= 1;
                    bombs += 1;
                    hasBomb = true;
                    Destroy(other.gameObject);
                }
                if (picktype.type == "Key")
                {
                    keys += 1;
                    storage -= 1;
                    hasKey = true;
                    Destroy(other.gameObject);
                }
            }
        }


    }
    private void OnTriggerStay(Collider other)
    {
        //needs work
        if (other.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }
}
