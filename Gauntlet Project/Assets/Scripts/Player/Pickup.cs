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
}
