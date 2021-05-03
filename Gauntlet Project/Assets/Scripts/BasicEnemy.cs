using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public Vector3 newpos;
    public Vector3 neweuler;
    public float speed = 0.03f;
    public int health;

    // Update is called once per frame
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        newpos = transform.position;
        neweuler = transform.eulerAngles;
        var playpos = player.GetComponent<PlayerMove>();
        if (playpos.transform.position.z > transform.position.z +0.3f)
        {

            if (!Physics.Raycast(transform.position, (Vector3.forward), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.right / 2, (Vector3.forward), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.left / 2, (Vector3.forward), speed + 0.5f))
            {
                newpos.z += speed;
                neweuler.y = 0;

            }
        }
        if (playpos.transform.position.z < transform.position.z - 0.3f)
        {

            if (!Physics.Raycast(transform.position, (Vector3.back), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.right / 2, (Vector3.back), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.left / 2, (Vector3.back), speed + 0.5f))
            {
                newpos.z -= speed;
                neweuler.y = 180;
               
            }
        }
        if (playpos.transform.position.x < transform.position.x -0.3f)
        {

            if (!Physics.Raycast(transform.position, (Vector3.left), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.forward / 2, (Vector3.left), speed + 0.5f) && !Physics.Raycast(transform.position + Vector3.back / 2, (Vector3.left), speed + 0.5f))
            {
                newpos.x -= speed;


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
                newpos.x += speed;
               
              
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
    }
    private void OnTriggerEnter(Collider other)
    {
        //if you get hit, take damage.
        //if that damage is lethal, die.
        if (other.gameObject.tag == "Bullet")
        {
            health -= 1;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
