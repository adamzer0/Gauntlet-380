using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //the type is what pickup it is.
    //the amount is how much it heals/gains if its food or money.
    //amount is ignored for keys and bombs.
    //types are: Food, Bomb, Key, Chest.
    public string type = "Food";
    public int amount = 100;
    public GameObject smallbomb;

    public AudioClip shotFood1; 
    public AudioClip shotFood2; 
    public AudioClip shotFood3;
    

    private int randomVal;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            if (type == "Food")
            {
                randomVal = Random.Range(1, 4);
                switch(randomVal)
                { 
                    case 1:

                        AudioSource.PlayClipAtPoint(shotFood1, transform.position);
                        Destroy(other.gameObject);
                        break;
                    case 2:
              
                        Destroy(other.gameObject);
                        AudioSource.PlayClipAtPoint(shotFood2, transform.position);
                        break;
                    case 3:
                      
                        Destroy(other.gameObject);
                        AudioSource.PlayClipAtPoint(shotFood3, transform.position);
                        break;

                    default:
                    
                        break;
                }//play one of three sounds if food is shot
                StartCoroutine(removeFood());

            }
            if (type == "Bomb")
            {
                Instantiate(smallbomb, transform.position, transform.rotation);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }

        }
        if (other.gameObject.tag == "Melee")
        {
            if (type == "Food")
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            if (type == "Bomb")
            {
                Instantiate(smallbomb, transform.position, transform.rotation);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }

        }
    }
    IEnumerator removeFood()
    {
        yield return new WaitForSeconds(1.7f);
        Destroy(this.gameObject);
    }
}
