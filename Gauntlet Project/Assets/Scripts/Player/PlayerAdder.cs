using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdder : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject target;
    public GameObject camera;
    public int play1exist = 0;
    public int play2exist = 0;
    public int play3exist = 0;
    public int play4exist = 0;
    // Update is called once per frame
    void Update()
    {
        /*this system is complicated, I will do my best to explain here.
         * When no players exist, any new player created will spawn at 0,0.
         * this would be an issue in most levels, however when there are no players
         * you cannot progress past level 0, thus its fine.
         * When there are players, the game will spawn any new player at the
         * camera's target player, starting with players 1 2 3 then 4.
         * If a player is killed they cannot respawn
         * The camera script has code to preven more players from being spawned
         * if there is a gameover.
         * Players are spawned with the 1 2 3 or 4 buttons (CHANGABLE)
         */
        var camplayer = camera.GetComponent<Camera>();
        if (Input.GetKeyDown("1") && play1exist == 0)
        {
            if (target != null)
            {
                camplayer.player = Instantiate(player1, target.transform.position, target.transform.rotation);
            }
            else
            {
                camplayer.player = Instantiate(player1, Vector3.zero, Quaternion.identity);
            }
            play1exist = 1;
            camplayer.playercount += 1;
            camplayer.notstarted = false;

        }
        if (Input.GetKeyDown("2") && play2exist == 0)
        {
            if (target != null)
            {
                camplayer.player2 = Instantiate(player2, target.transform.position, target.transform.rotation);
            }
            else 
            { 
            camplayer.player2 = Instantiate(player2, Vector3.zero, Quaternion.identity); 
            }
            play2exist = 1;
            camplayer.playercount += 1;
            camplayer.notstarted = false;
        }
        if (Input.GetKeyDown("3") && play3exist == 0)
        {
            if (target != null)
            {
                camplayer.player3 = Instantiate(player3, target.transform.position, target.transform.rotation);
            }
            else
            {
                camplayer.player3 = Instantiate(player3, Vector3.zero, Quaternion.identity);
            }
            play3exist = 1;
            camplayer.playercount += 1;
            camplayer.notstarted = false;
        }
        if (Input.GetKeyDown("4") && play4exist == 0)
        {
            if (target != null)
            {
                camplayer.player4 = Instantiate(player4, target.transform.position, target.transform.rotation);
            }
            else
            {
                camplayer.player4 = Instantiate(player4, Vector3.zero, Quaternion.identity);
            }
            play4exist = 1;
            camplayer.playercount += 1;
            camplayer.notstarted = false;
        }
    }
}
