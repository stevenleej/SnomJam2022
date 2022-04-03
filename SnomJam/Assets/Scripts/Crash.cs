using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    [SerializeField] private LaneManager laneManager;
    [SerializeField] private GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            laneManager.StopMoving();
            gameManager.isGameOver = true;
        }
    }
}
