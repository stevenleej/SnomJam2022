using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    [SerializeField] private Menu menu;
    [SerializeField] private TruckMovement truckMovement;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float laneSpeed;

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameStarted)
        {
            transform.Translate(Vector3.left * laneSpeed * Time.deltaTime);   
        }

        laneSpeed = menu.SpeedometerSlider.value;
    }

    public void decreaseSpeed(float substracteeValue)
    {
        menu.SpeedometerSlider.value -= substracteeValue;
    }

    public void StopMoving()
    {
        menu.SpeedometerSlider.value = 0f;
    }

    public float GetSpeed()
    {
        return laneSpeed;
    }
}
