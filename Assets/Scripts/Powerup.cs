using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    public bool isActive = false;
    public float duration = 1;
}
