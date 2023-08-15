using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OxygenManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI timerTxt;
    [SerializeField] private float duration;

    private void Awake()
    {
        timerTxt.text = duration.ToString();
        slider.maxValue = duration;
    }

    void Update()
    {
        if (duration > 0)
        {
            duration -= Time.deltaTime;
            slider.value = duration;
            timerTxt.text = Mathf.Ceil(duration).ToString();
        }
        else
        {
            GameManager.instance.GameOver();
        }
    }
}
