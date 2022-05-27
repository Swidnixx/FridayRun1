using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    public int level = 1;
    public int upgradeCost = 100;

    [HideInInspector]
    public bool isActive = false;
    public float duration = 1;
}
