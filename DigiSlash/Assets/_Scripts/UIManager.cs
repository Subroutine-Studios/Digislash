using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    
    public Fort fortHealth;
    public Image fortFillImage;
    public Slider fortSlider;

    public Player player;
    public Image playerFillImage;
    public Slider playerSlider;


    // weapon switch labels

    public Text weap1Txt;
    public Text weap2Txt;
    public Text weap1Subtype1Txt;
    public Text weap1Subtype2Txt;
    public Text weap2Subtype1Txt;
    public Text weap2Subtype2Txt;






    void Start()
    {
        // Set weapon labels


    }

    // Update is called once per frame
    void Update()
    {

        updateFortHp();
        updatePlayerHp();

        // get current weapon
        // weawpon index 0 - bullet ; 1 - rocket
        
       

        if (player._weaponIndex == 0)
        {
            // highlight bullet
            weap1Txt.color = new Color32(255, 255, 255, 255);
            weap2Txt.color = new Color32(255, 255, 255, 70);


        }
        else if(player._weaponIndex == 1)
        {

            // highlight rocket
            weap2Txt.color = new Color32(255, 255, 255, 255);
            weap1Txt.color = new Color32(255, 255, 255, 70); 



        }





    }



    void updateFortHp()
    {

        if (fortSlider.value <= fortSlider.minValue)
        {
            fortFillImage.enabled = false;
        }

        else if (fortSlider.value > fortSlider.minValue && !fortFillImage.enabled)
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


        float fillValue = player.health / 200f; // player current health/ player max health

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
