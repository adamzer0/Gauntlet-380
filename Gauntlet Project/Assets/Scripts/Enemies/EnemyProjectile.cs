using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public float speed = 0.1f;
    //this projectile goes forward every frame by its speed.
    public void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * 60);
    }
    //when it hits a wall it dissapates.
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Door")
        {
            Destroy(gameObject);
        }
    }
}
