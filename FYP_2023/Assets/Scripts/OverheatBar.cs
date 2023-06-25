using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverheatBar : MonoBehaviour
{
    public Slider slider;
    public void setMaxOverheat(float overheat)
    {
        slider.maxValue = overheat;
        slider.value = 0;
    }
    public void setOverheat(float overheat)
    {
        slider.value = overheat;
    }
}
