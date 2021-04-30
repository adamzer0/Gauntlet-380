using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int spawndelay = 30;
    public int maxspawndelay = 100;
    public GameObject spawntype;
    public int health = 100;
    // Update is called once per frame
    void Update()
    {
        spawndelay -= 1;
        if (spawndelay<= 0)
        {
            spawndelay = maxspawndelay;
            Instantiate(spawntype, transform.position, transform.rotation);
        }
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
