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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
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
}
