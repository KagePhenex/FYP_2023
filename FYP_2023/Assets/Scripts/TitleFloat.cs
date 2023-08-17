using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFloat : MonoBehaviour
{
    [SerializeField] private float floatThreshold; //Threshold of which the object can bounce
    [SerializeField] private float speed; //Speed of the bounce

    private Vector2 ogPosY; //Original Y position

    void Start()
    {
        ogPosY = transform.position; //move on Y-axis 
    }

    void Update()
    {
        // Bounces game object
        transform.position = ogPosY + new Vector2(0, Mathf.Sin(Time.time * speed) * floatThreshold / 2.0f); 
    }
}
