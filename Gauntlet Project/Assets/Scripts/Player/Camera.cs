using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public Vector3 dist2;
    public Vector3 dist3;
    public Vector3 dist4;
    public Vector3 mypos;
    public int playercount = 1;
    void Update()
    {
        mypos = player.transform.position;
        if (player2 != null)
        {
            dist2 = player2.transform.position - player.transform.position;
            dist2 /= playercount;
        }
        if (player3 != null)
        {
            dist3 = player3.transform.position - player.transform.position;
            dist3 /= playercount;
        }
        if (player4 != null)
        {
            dist4 = player4.transform.position - player.transform.position;
            dist4 /= playercount;
        }


       
        mypos += dist2 + dist3 + dist4;
        mypos.y += 10;
        transform.position = mypos;
    }
}
