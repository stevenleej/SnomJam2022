using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacles : MonoBehaviour
{
    public abstract void InteractOnContact(GameObject parent);

    public virtual float GetSpeedPenalty()
    {
        Debug.Log("class misassigned from Obstacles");
        return 0f;
    }
}
