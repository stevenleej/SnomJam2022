using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RollChildrenOnStreet : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Transform[] childList = GetComponentsInChildren<Transform>();
        foreach (var child in childList.Skip(0))
        {
            if (childList.Length > 0)
            {
                child.RotateAround(child.transform.position, Vector3.forward, 360 * Time.deltaTime);
            }
        }
    }
}
