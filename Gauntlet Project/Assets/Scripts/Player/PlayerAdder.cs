using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdder : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    //used to setup camera.
    public GameObject camera;
    public int play2exist = 0;
    public int play3exist = 0;
    public int play4exist = 0;
    // Update is called once per frame
    void Update()
    {
        var camplayer = camera.GetComponent<Camera>();
        if (Input.GetKeyDown("1") && play2exist == 0)
        {
            camplayer.player2 = Instantiate(player2, player1.transform.position, player1.transform.rotation);
            play2exist = 1;
            camplayer.playercount += 1;

        }
        if (Input.GetKeyDown("2") && play3exist == 0)
        {
            camplayer.player3 = Instantiate(player3, player1.transform.position, player1.transform.rotation);
            play3exist = 1;
            camplayer.playercount += 1;
        }
        if (Input.GetKeyDown("3") && play4exist == 0)
        {
            camplayer.player4 = Instantiate(player4, player1.transform.position, player1.transform.rotation);
            play4exist = 1;
            camplayer.playercount += 1;
        }
    }
}
