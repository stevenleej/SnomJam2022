using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockade : Obstacles
{
    public override void InteractOnContact(GameObject parent)
    {
        Debug.Log("Car crashed");
    }
}
