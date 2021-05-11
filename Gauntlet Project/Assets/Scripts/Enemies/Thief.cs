using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : BasicEnemy
{
    public bool stole = false;
    public bool stoleBomb = false;
    public bool stoleKeys = false;
    public GameObject bomb;
    public GameObject key;
    public GameObject treasure; 

    int randomVal;
  
    public override void Update()
    {
       if(health<=0)
        {
            if (stole == true)
            {
                if (stoleBomb == true)
                {
                    Instantiate(bomb, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                }
                else if (stoleKeys == true)
                {
                    Instantiate(key, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                }
                else
                {
                    treasure.GetComponent<Pickup>().amount = randomVal;
                    Instantiate(treasure, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                }
            }
            else
            {
                treasure.GetComponent<Pickup>().amount = 500;
                Instantiate(treasure, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }//death 
        if (stole == true && health > 0)
        {
            if (Vector3.Distance(player.transform.position, this.transform.position) > 10)
            {
                Destroy(this.gameObject);
            }
        }
        base.Update(); 
    }
    public override void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.tag=="Player")
        {
            player.GetComponent<PlayerMove>().health -= 10;
            this.speed = -speed; 
            if (player.GetComponent<PlayerMove>().bombs>0)
            {
                player.GetComponent<PlayerMove>().bombs -= 1;
                player.GetComponent<PlayerMove>().storage += 1;
                stole = true; 
                stoleBomb = true; 
            }
            else if(player.GetComponent<PlayerMove>().keys >0)
            {
                player.GetComponent<PlayerMove>().keys -= 1;
                player.GetComponent<PlayerMove>().storage += 1;
                stole = true;
                stoleKeys = true;
            }
            else
            {
                randomVal = Random.Range(1, 101);
                stole = true;
                player.GetComponent<PlayerMove>().score -= randomVal;
            }
      }
        base.OnTriggerEnter(other);
    }
}
