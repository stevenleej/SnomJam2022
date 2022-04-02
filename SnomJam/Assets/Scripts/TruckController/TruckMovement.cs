using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    [Header("Player Properties")]
    [SerializeField] private float acceleration;
    [SerializeField] private float laneOffset;
    [SerializeField] private bool isChangingLane;
    [SerializeField] private List<Transform> laneList;

    [SerializeField]
    public enum laneState
    {
        lane1,
        lane2,
        lane3,
        lane4
    };

    [SerializeField] laneState currentLaneState;
    
    void Start()
    {
        currentLaneState = laneState.lane2;
        isChangingLane = false;
    }
    
    //runs the player loop for moving
    public void LoopPlayerMovement()
    {
        CheckForLaneChange();
    }
    
    //substracts the player's origin when they collide with a collectible object
    public void PenalizePlayer(float substractedDistance)
    {
        //TODO
    }

    public void SetSpeed(float modifiedSpeed)
    {
        this.acceleration = modifiedSpeed;
    }

    public float GetSpeed()
    {
        return acceleration;
    }

    /*
     * Methods run to move the player in the game loop
     */
    
    private void CheckForLaneChange()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            switch (currentLaneState)
            {
                case laneState.lane2:
                    MoveUpLaneState(laneState.lane1);
                    break;
                case laneState.lane3:
                    MoveUpLaneState(laneState.lane2);
                    break;
                case laneState.lane4:
                    MoveUpLaneState(laneState.lane3);
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            switch (currentLaneState)
            {
                case laneState.lane1:
                    MoveDownLaneState(laneState.lane2);
                    break;
                case laneState.lane2:
                    MoveDownLaneState(laneState.lane3);
                    break;
                case laneState.lane3:
                    MoveDownLaneState(laneState.lane4);
                    break;
            }
        }
    }

    private void MoveUpLaneState(laneState l)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + laneOffset, 1f);
        currentLaneState = l;
    }
    
    private void MoveDownLaneState(laneState l)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - laneOffset, 1f);
        currentLaneState = l;
    }




}
