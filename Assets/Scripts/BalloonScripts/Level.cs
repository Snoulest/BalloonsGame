using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level")]
public class Level : ScriptableObject
{
    public int pointsReq;
    public float waitTime;
    public float ySpeed;
    public bool active;
}
