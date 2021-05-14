using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    //movement based
    public Vector3 newpos;
    public Vector3 neweuler;
    public float speed = 0.03f;
    public int health;

    public int scoregive;




    // Update is called once per frame
    public virtual void Awake()
    {
       
        player = GameObject.FindWithTag("Player");
    }
    public virtual void Update()
    {

            //set up position and eulers. based on the target player's position
            //this entity will
            newpos = transform.position;
            neweuler = transform.eulerAngles;
            var playpos = player.GetComponent<PlayerMove>();
            if (playpos.transform.position.z > transform.position.z + 0.3f)
            {

                if (!Physics.Raycast(transform.position, (Vector3.forward), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.right / 2, (Vector3.forward), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.left / 2, (Vector3.forward), speed + 0.5f))
                {
                    newpos.z += speed * Time.deltaTime * 60;
                    neweuler.y = 0;

                }
            }
            if (playpos.transform.position.z < transform.position.z - 0.3f)
            {

                if (!Physics.Raycast(transform.position, (Vector3.back), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.right / 2, (Vector3.back), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.left / 2, (Vector3.back), speed + 0.5f))
                {
                    newpos.z -= speed * Time.deltaTime * 60;
                    neweuler.y = 180;

                }
            }
            if (playpos.transform.position.x < transform.position.x - 0.3f)
            {

                if (!Physics.Raycast(transform.position, (Vector3.left), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.forward / 2, (Vector3.left), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.back / 2, (Vector3.left), speed + 0.5f))
                {
                    newpos.x -= speed * Time.deltaTime * 60;


                    if (neweuler.y >= -5 && neweuler.y <= 5)
                    {

                        neweuler.y = 315;
                    }
                    else if (neweuler.y >= 175 && neweuler.y <= 185)
                    {

                        neweuler.y = 235;

                    }
                    else
                    {
                        neweuler.y = 270;
                    }
                }
            }
            if (playpos.transform.position.x > transform.position.x + 0.3f)
            {

                if (!Physics.Raycast(transform.position, (Vector3.right), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.forward / 2, (Vector3.right), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.back / 2, (Vector3.right), speed + 0.5f))
                {
                    newpos.x += speed * Time.deltaTime * 60;


                    if (neweuler.y >= -5 && neweuler.y <= 5)
                    {

                        neweuler.y = 45;
                    }
                    else if (neweuler.y >= 175 && neweuler.y <= 185)
                    {

                        neweuler.y = 135;
                    }
                    else
                    {
                        neweuler.y = 90;
                    }

                }
            }
            transform.eulerAngles = neweuler;
            transform.position = newpos;
            // if projectile enemy not delayed (instantiate projectile)
            //start firing delay coroutine
            if (health <= 0)
            {
                var givescore = player.GetComponent<PlayerMove>();
                givescore.score += scoregive;
                Destroy(gameObject);
            }
        
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        //if you get hit, take damage.
        //if that damage is lethal, die.
        if (other.gameObject.tag == "Bullet")
        {
            var bulletdmg = other.GetComponent<BulletMove>();
            var bulletowner = other.GetComponent<RemoveSelf>();
            player = bulletowner.myowner;
            health -= bulletdmg.damage;
            

            Destroy(other.gameObject);
        }

        if (other.tag == "Bomb")
        {
            var bombdmg = other.GetComponent<RemoveSelf>();
            health -= bombdmg.mypower;
            if (bombdmg.myowner != null)
            {
                player = bombdmg.myowner;
            }
           
        }
        if (other.tag == "Melee")
        {
            var bulletowner = other.GetComponent<RemoveSelf>();
            player = bulletowner.myowner;
            health -= 1;
        }
        if (other.tag == "WMelee")
        {
            health -= 3;
        }
    }
}
