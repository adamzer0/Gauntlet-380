using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int spawndelay = 30;
    public int maxspawndelay = 100;
    public GameObject spawntype;
    public int health = 100;
    private float maxhealth = 10;
    public Vector3 myscale;
    // Update is called once per frame
    private void Awake()
    {
        maxhealth = health;
    }
    void Update()
    {

        spawndelay -= 1;
        if (spawndelay<= 0)
        {
            spawndelay = maxspawndelay;
            Instantiate(spawntype, transform.position, transform.rotation);
        }
        myscale.x = ((health +maxhealth/3) / (maxhealth + maxhealth / 3));
        myscale.y = myscale.x;
        myscale.z = myscale.x;
        transform.localScale = myscale;
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
