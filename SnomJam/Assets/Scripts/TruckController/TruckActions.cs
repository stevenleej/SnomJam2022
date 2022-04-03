using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckActions : MonoBehaviour
{
    private TruckMovement truckMovement;
    [SerializeField] private GameManager GameManager;
    [SerializeField] private GameObject laneManager;
    [SerializeField] private Sprite deadDogs;
    private void Awake()
    {
        truckMovement = GetComponent<TruckMovement>();
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("collectable"))
        {
            Debug.Log("collided");
            Obstacles co = other.GetComponent<Obstacles>();
            co.InteractOnContact(gameObject);
            co.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //reduce truck's speed, although might need refactoring here in the future. Most likely not as useful for a jam.
            truckMovement.PenalizePlayer(co.GetSpeedPenalty());
        }
        else if (other.CompareTag("blockade"))
        {
            Obstacles co = other.GetComponent<Obstacles>();
            co.InteractOnContact(gameObject);
            GameManager.isGameOver = true;
            laneManager.GetComponent<LaneManager>().StopMoving();
            //play truck explosion animation here
            GetComponent<SpriteRenderer>().sprite = deadDogs;
        }
    }
}
