﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // cannot init here, because static will carry on from one scene to another    public int startMoney = 400;
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 10;

    public static int Rounds;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
    }
}
