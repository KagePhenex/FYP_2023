using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFloat : MonoBehaviour
{
    [SerializeField] private float upperThreshold, lowerThreshold, speed;
    void FixedUpdate()
    {
        float _speed = speed;
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
        if (transform.position.y < lowerThreshold)
        {
            _speed = speed;
        }
        else if (transform.position.y > upperThreshold)
        {
            _speed = -speed;
        }
    }
}
