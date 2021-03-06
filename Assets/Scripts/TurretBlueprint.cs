﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Save & Load Values
[System.Serializable]

public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return (int)(cost * 0.5);
    }

    public Turret GetTurret()
    {
        return prefab.GetComponent<Turret>();
    }
}