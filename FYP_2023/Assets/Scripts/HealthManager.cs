using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    public static HealthManager instance { get; private set; }
    [SerializeField] private Slider slider; //Slider
    [SerializeField] private GameObject meter; //Slider fill

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    //Set Slider Max Value
    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
    }
    //Update slider value
    public void updateHealth(float health)
    {
        slider.value = health;
        //If damaged once, change fill to yellow
        if (health <= slider.maxValue - 1)
        {
            Debug.Log("Health Damaged");
            meter.GetComponent<Image>().color = Color.yellow;
        }
        //If 1 hit left, change fill to red
        if (health == 1)
        {
            meter.GetComponent<Image>().color = Color.red;
        }
        //Display game over canvas when health is less than or equal to 0
        if (health <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
