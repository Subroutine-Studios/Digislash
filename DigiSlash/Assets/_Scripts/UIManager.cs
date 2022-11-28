using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    public Fort fortHealth;
    public Image fortFillImage;
    public Slider fortSlider;

    public Player playerHealth;
    public Image playerFillImage;
    public Slider playerSlider;

    void Awake()
    {


    }

    // Update is called once per frame
    void Update()
    {

        updateFortHp();
        updatePlayerHp();
    }


    void updateFortHp()
    {

        if (fortSlider.value <= fortSlider.minValue)
        {
            fortFillImage.enabled = false;
        }

        if (fortSlider.value > fortSlider.minValue && !fortFillImage.enabled)
        {
            fortFillImage.enabled = true;
        }


        float fillValue = fortHealth._leaks / 10f; // fort current health/ fort max health

        if (fillValue <= fortSlider.maxValue / 3)
        {
            fortFillImage.color = Color.yellow;
        }
        else if (fillValue > fortSlider.maxValue / 3)
        {
            fortFillImage.color = Color.green;
        }

        fortSlider.value = fillValue;

    }

    void updatePlayerHp()
    {
        if (playerSlider.value <= playerSlider.minValue)
        {
            playerFillImage.enabled = false;
        }

        if (playerSlider.value > playerSlider.minValue && !playerFillImage.enabled)
        {
            playerFillImage.enabled = true;
        }


        float fillValue = playerHealth.health / 200f; // player current health/ player max health

        if (fillValue <= playerSlider.maxValue / 3)
        {
            playerFillImage.color = Color.yellow;
        }
        else if (fillValue > playerSlider.maxValue / 3)
        {
            playerFillImage.color = Color.red;
        }

        playerSlider.value = fillValue;

    }

    
}
