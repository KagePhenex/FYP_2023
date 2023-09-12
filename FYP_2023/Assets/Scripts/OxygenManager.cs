using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OxygenManager : MonoBehaviour
{
    [SerializeField] private Slider slider; //Slider
    [SerializeField] private TextMeshProUGUI timerTxt; //Timer Text
    [SerializeField] private float duration; //Timer Duration

    private void Awake()
    {
        //Set timer and slider to duration
        timerTxt.text = duration.ToString();
        slider.maxValue = duration;
    }

    void Update()
    {
        //If duraton is above 0, count down timer and update slider value
        if (duration > 0)
        {
            duration -= Time.deltaTime; //Count down timer
            slider.value = duration;
            timerTxt.text = Mathf.Ceil(duration).ToString(); //Round up duration
        }
        else //When duration is below 0, game ends
        {
            GameManager.instance.GameOver();
        }
    }
}
