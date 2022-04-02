using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : Obstacles
{
    [SerializeField] private ObstacleData obstacleData;
    private void Start()
    {
        
    }

    public override float GetSpeedPenalty()
    {
        return obstacleData.decreaseSpeedValue;
    }

    public override void InteractOnContact(GameObject parent)
    {
        gameObject.transform.SetParent(parent.transform, true);
    }
}
