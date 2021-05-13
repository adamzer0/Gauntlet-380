using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject target;
    public GameObject playeradd;
    public Vector3 dist2;
    public Vector3 dist3;
    public Vector3 dist4;
    public Vector3 mypos;
    public bool notstarted = true;
    public int playercount = 1;
    private void Awake()
    {
        target = null;

    }
    void Update()
    {
        //prevents a gameover before the game starts
        if (notstarted == false)
        {
            //this follows the first living player.
            //if a player dies, it follows the next and so on.
            if (player != null)
            {
                mypos = player.transform.position;
                target = player;
                if (player.transform.tag == "Untagged")
                {
                    player = null;
                    playercount -= 1;

                }
            }
            else
            {
                if (player2 != null)
                {
                    target = player2;
                    mypos = player2.transform.position;
                }
                else
                {
                    if (player3 != null)
                    {
                        target = player3;
                        mypos = player3.transform.position;
                    }
                    else
                    {
                        if (player4 != null)
                        {
                            target = player4;
                            mypos = player4.transform.position;
                        }
                        else
                        {
                            Debug.Log("Gameover!");
                            var gameover = playeradd.GetComponent<PlayerAdder>();
                            Destroy(playeradd.gameObject);
                            SceneManager.LoadScene("GameOver");
                            notstarted = true;
                            Destroy(gameObject);
                            
                        }
                    }
                }
            }
            var addtarget = playeradd.GetComponent<PlayerAdder>();
            addtarget.target = target;
            if (player2 != null)
            {
                dist2 = player2.transform.position - target.transform.position;
                dist2 /= playercount;
                if (player2.transform.tag == "Untagged")
                {
                    playercount -= 1;
                    dist2 = Vector3.zero;
                    player2 = null;
                }
            }
            if (player3 != null)
            {
                dist3 = player3.transform.position - target.transform.position;
                dist3 /= playercount;
                if (player3.transform.tag == "Untagged")
                {
                    playercount -= 1;
                    dist3 = Vector3.zero;
                    player3 = null;
                }
            }
            if (player4 != null)
            {
                dist4 = player4.transform.position - target.transform.position;
                dist4 /= playercount;
                if (player4.transform.tag == "Untagged")
                {
                    playercount -= 1;
                    dist4 = Vector3.zero;
                    player4 = null;

                }
            }






            if (notstarted == false)
            {
                mypos += dist2 + dist3 + dist4;
                mypos.y += 10;
                transform.position = mypos;
            }
        }
    }
}
