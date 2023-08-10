using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    public static HealthManager instance { get; private set; }
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject meter;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
    }
    public void updateHealth(float health)
    {
        slider.value = health;
        if (health <= slider.maxValue - 1)
        {
            Debug.Log("Health Damaged");
            meter.GetComponent<Image>().color = Color.yellow;
        }
        if (health == 1)
        {
            meter.GetComponent<Image>().color = Color.red;
        }
        if (health <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
