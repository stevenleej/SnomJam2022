using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text SpeedometerText;
    public Slider SpeedometerSlider;
    public GameObject MenuTitle;
    public GameObject LerpStart;
    public GameObject LerpEnd;

    bool StartButtonClicked;
    float timer;

    private void Update()
    {
        SpeedometerText.text = SpeedometerSlider.value.ToString();
        
        if(StartButtonClicked)
        {
            timer = (timer + Time.deltaTime);
            MenuTitle.transform.position = Vector3.Lerp(LerpStart.transform.position, LerpEnd.transform.position, timer);
            if (timer >= 1)
            {
                StartButtonClicked = false;
            }
        }
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnStartButton()
    {
        StartButtonClicked = true;
    }
}
