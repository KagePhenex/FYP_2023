using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisBehaviour : MonoBehaviour
{
    private float randRotation;
    // Start is called before the first frame update
    void Awake()
    {
        randRotation = Random.Range(-30, 30);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, randRotation * Time.deltaTime);
    }
}
