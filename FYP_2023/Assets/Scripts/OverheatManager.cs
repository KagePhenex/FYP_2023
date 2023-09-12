using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverheatManager : MonoBehaviour
{
    public static OverheatManager instance { get; private set; }
    [SerializeField] private Slider slider; //Slider
    [SerializeField] private GameObject overheatTxt; //Overheat Text

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    //Set Slider Max Value and set its current value to 0
    public void setMaxHeat(float overheat)
    {
        slider.maxValue = overheat;
        slider.value = 0;
    }
    //Update slider value
    public void updateHeat(float overheat)
    {
        slider.value = overheat;
    }
    //Display overheat text
    public void displayOverheatTxt(bool overheated)
    {
        overheatTxt.SetActive(overheated);
    }
}
