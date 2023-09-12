using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisBehaviour : MonoBehaviour
{
    private float randRotation; //Random rotation
    private void Awake()
    {
        randRotation = Random.Range(-30, 30);
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, randRotation * Time.deltaTime); //Add rotation to debris
    }
}
