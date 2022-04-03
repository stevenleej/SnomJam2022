using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckActions : MonoBehaviour
{
    private TruckMovement truckMovement;

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
    }
}
