using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillMover : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float hillAreMovingSpeed;
    private void LateUpdate()
    {
        if (gameManager.gameStarted && !gameManager.isGameOver)
        {
            transform.Translate(Vector3.left * hillAreMovingSpeed * Time.deltaTime);         
        }
    }
}
