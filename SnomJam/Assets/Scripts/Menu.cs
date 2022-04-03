using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text SpeedometerText;
    public Slider SpeedometerSlider;
    public GameObject MenuTitle;
    public GameObject QuitButton;
    public GameObject MenuLerpStart;
    public GameObject MenuLerpEnd;
    public GameObject QuitLerpStart;
    public GameObject QuitLerpEnd;

    bool StartButtonClicked;
    float timer;

    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        SpeedometerSlider.value = 8.8f;
    }

    private void Update()
    {
        float convertedValue = SpeedometerSlider.value * 10;
        SpeedometerText.text = convertedValue.ToString();
        
        if(StartButtonClicked)
        {
            timer = (timer + Time.deltaTime);
            MenuTitle.transform.position = Vector3.Lerp(MenuLerpStart.transform.position, MenuLerpEnd.transform.position, timer);
            QuitButton.transform.position = Vector3.Lerp(QuitLerpStart.transform.position, QuitLerpEnd.transform.position, timer);
            if (timer >= 1)
            {
                StartButtonClicked = false;
            }
        }
    }


    public bool SendGameStarted()
    {
        return StartButtonClicked;
    }

    public void OnQuitButton()
    {
        if (gameManager.isGameOver)
        {
            SceneManager.LoadScene(0);   
        }
        else
        {
            Application.Quit();
        }
    }

    public void OnStartButton()
    {
        StartButtonClicked = true;
        gameManager.gameStarted = true;
    }
}
