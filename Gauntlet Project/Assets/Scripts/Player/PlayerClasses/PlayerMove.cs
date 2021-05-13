using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    //new position and direction for movement
    public Vector3 newpos;
    public Vector3 neweuler;
    //you know what speed is
    public float speed = 0.1f;
    public int bombdamage = 1;
    public int armor = 0;
    public int bulletdamage = 1;
    //direction you shoot in, set when you move
    private string shootdirection = "right";
    //the projectile that the class shoots.
    public GameObject projectile;
    public GameObject bigbomb;
    public GameObject meleeweapon;
    //for dontdestroyonreload
    public GameObject spawner;
    public GameObject Cam;
    //for setting bomb damage
    public GameObject mylastbomb;
    public GameObject mylastbullet;


    //health drains slowly
    public int healthlosstimermax = 30;
    public int healthlosstimer = 30;
    //health
    public int health = 600;
    public int score = 0;
    public int bombs = 0;
    public int keys = 0;
    //max storage for bombs and keys
    public int storage = 10;
    //this will prevent you from using multiple keys on the same door.
    public int unlockdoor = 0;
   
   

    //to prevent a bug, myright is true.
    //without this fix, bullets fired before moving go the wrong direction
    public bool myup = false;
    public bool mydown = false;
    public bool myleft = false;
    public bool myright = true;
    public bool firing = false;
    public bool usebomb = false;
    public bool melee = false;

    private void Awake()
    {
        spawner = GameObject.FindWithTag("Spawner");
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(spawner.gameObject);
        Cam = GameObject.FindWithTag("MainCamera");
        DontDestroyOnLoad(Cam.gameObject);
    }

    public virtual void Update()
    {
        if (health <= 0)
        {
            gameObject.transform.tag = "Untagged";
            gameObject.layer = 2;
           
        }
        else
        {
            healthlosstimer -= 1;
            if (healthlosstimer <= 0)
            {
                health -= 1;
                healthlosstimer = healthlosstimermax;
            }
            //basic setting up of rotation and movement;
            neweuler = transform.eulerAngles;
            newpos = transform.position;
            //this system creates a total of 12 raycasts, checking the top bottom and middle of the character for geometry. 
            //If it runs into anything that it can raycast hit, the player cannot move in said direction
            //as the player can attack through corner gaps, the player can face a wall, just not move into said wall.
            if (myup)
            {
                Debug.Log("my up is true");
                shootdirection = "up";
                neweuler.y = 0;
                if (!Physics.Raycast(transform.position, (Vector3.forward), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.right / 2, (Vector3.forward), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.left / 2, (Vector3.forward), speed + 0.5f))
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
                    mylastbullet = Instantiate(projectile, transform.position + Vector3.forward, transform.rotation);
                }
                if (shootdirection == "down")
                {
                    mylastbullet = Instantiate(projectile, transform.position + Vector3.back, transform.rotation);
                }
                if (shootdirection == "left")
                {
                    mylastbullet = Instantiate(projectile, transform.position + Vector3.left, transform.rotation);
                }
                if (shootdirection == "right")
                {
                    mylastbullet = Instantiate(projectile, transform.position + Vector3.right, transform.rotation);
                }
                if (shootdirection == "uright")
                {
                    mylastbullet = Instantiate(projectile, transform.position + Vector3.right + Vector3.forward, transform.rotation);
                }
                if (shootdirection == "dright")
                {
                    mylastbullet = Instantiate(projectile, transform.position + Vector3.right + Vector3.back, transform.rotation);
                }
                if (shootdirection == "uleft")
                {
                    mylastbullet = Instantiate(projectile, transform.position + Vector3.left + Vector3.forward, transform.rotation);
                }
                if (shootdirection == "dleft")
                {
                    mylastbullet = Instantiate(projectile, transform.position + Vector3.left + Vector3.down, transform.rotation);
                }
                var lastshot = mylastbullet.GetComponent<BulletMove>();
                lastshot.damage = bulletdamage;

                //dont let the player fire a beam;

                firing = false;
            }
            if (melee)
            {


                if (shootdirection == "up")
                {
                    Instantiate(meleeweapon, transform.position + Vector3.forward, transform.rotation);
                }
                if (shootdirection == "down")
                {
                    Instantiate(meleeweapon, transform.position + Vector3.back, transform.rotation);
                }
                if (shootdirection == "left")
                {
                    Instantiate(meleeweapon, transform.position + Vector3.left, transform.rotation);
                }
                if (shootdirection == "right")
                {
                    Instantiate(meleeweapon, transform.position + Vector3.right, transform.rotation);
                }
                if (shootdirection == "uright")
                {
                    Instantiate(meleeweapon, transform.position + Vector3.right + Vector3.forward, transform.rotation);
                }
                if (shootdirection == "dright")
                {
                    Instantiate(meleeweapon, transform.position + Vector3.right + Vector3.back, transform.rotation);
                }
                if (shootdirection == "uleft")
                {
                    Instantiate(meleeweapon, transform.position + Vector3.left + Vector3.forward, transform.rotation);
                }
                if (shootdirection == "dleft")
                {
                    Instantiate(meleeweapon, transform.position + Vector3.left + Vector3.down, transform.rotation);
                }

                //dont let the player fire a beam;

                melee = false;
            }
            //when you're using a bomb, it kills everything on screen
            if (usebomb && bombs >= 1)
            {
                //remove the bomb and free up storage
                bombs -= 1;
                storage += 1;
                //setup bomb damage
                mylastbomb = Instantiate(bigbomb, transform.position, transform.rotation);
                var bombdmg = mylastbomb.GetComponent<RemoveSelf>();
                bombdmg.mypower = bombdamage;
                //disables bombs being used
                Debug.Log("bombplace");
                usebomb = false;
            }
            //this removes all inputs, as inputs are declared in another script
            myup = false;
            mydown = false;
            myleft = false;
            myright = false;
            //prevents unlocking the same door with multiple keys
            if (unlockdoor >= 0)
            {
                unlockdoor -= 1;
            }
            //let the player fire again
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (health <= 0)
        {
            if (other.gameObject.tag == "Transfer")
            {
                Destroy(gameObject);
            }
        }
            if (health > 0)
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
                //if you dont you wont pick them up
                if (storage >= 1)
                {
                    if (picktype.type == "Bomb")
                    {
                        storage -= 1;
                        bombs += 1;

                        Destroy(other.gameObject);
                    }
                    if (picktype.type == "Key")
                    {
                        keys += 1;
                        storage -= 1;

                        Destroy(other.gameObject);
                    }
                }
            }
            if (other.gameObject.tag == "Door")
            {
                if (keys >= 1 && unlockdoor <= 0)
                {
                    keys -= 1;
                    storage += 1;
                    Destroy(other.transform.parent.gameObject);
                    unlockdoor = 2;
                }
            }
            //the transfer object will set your position at the start of a level
            if (other.gameObject.tag == "Transfer")
            {
                var moveto = other.GetComponent<Teleporter>();
                transform.position = moveto.startpos;
            }
            //teleports you to the next level.
            if (other.gameObject.tag == "Exit")
            {
                var sceneman = other.GetComponent<Stairs>();
                SceneManager.LoadScene(sceneman.nextlevel);

            }

            //enemies do a range of damage, lowered by armor.
            if (other.gameObject.tag == "Enemy")
            {
                health -= Random.Range(3, 10) - armor;
            }
            if (other.gameObject.tag == "EnemyBullet")
            {
                health -= Random.Range(3, 10) - armor;
                Destroy(other.gameObject);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (health > 0)
        {
            if (other.gameObject.tag == "Death")
            {
                health -= 1 - armor;
            }
        }
    }

}
