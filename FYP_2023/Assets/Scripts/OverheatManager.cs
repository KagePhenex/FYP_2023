using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverheatManager : MonoBehaviour
{
    public static OverheatManager instance { get; private set; }
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject overheatTxt;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void setMaxHeat(float overheat)
    {
        slider.maxValue = overheat;
        slider.value = 0;
    }
    public void updateHeat(float overheat)
    {
        slider.value = overheat;
    }
    public void displayOverheatTxt(bool overheated)
    {
        overheatTxt.SetActive(overheated);
    }
}
