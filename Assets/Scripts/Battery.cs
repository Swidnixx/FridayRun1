using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Battery : ScriptableObject
{
    public bool isActive = false;
    public float speedBoost = 0.1f;
    public float duration = 1;
}
