using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    [SerializeField] private TruckMovement truckMovement;
    [SerializeField] private float laneSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * laneSpeed * Time.deltaTime);
    }

    public void decreaseSpeed(float substracteeValue)
    {
        laneSpeed -= substracteeValue;
    }

    public void StopMoving()
    {
        laneSpeed = 0f;
    }
}
