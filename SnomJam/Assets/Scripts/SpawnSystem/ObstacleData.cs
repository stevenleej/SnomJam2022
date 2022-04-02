using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Name of Obstacle", menuName = "Obstacle Data/new data", order = 1)]
public class ObstacleData : ScriptableObject
{
    public string name;
    public float decreaseSpeedValue;
}
