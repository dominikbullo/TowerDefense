using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money; // cannot init here, because static will carry on from one scene to another 
    public int startMoney = 400;
    void Start()
    {
        Money = startMoney;
    }
}
