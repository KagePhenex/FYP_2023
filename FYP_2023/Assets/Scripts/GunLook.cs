using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLook: MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(Input.mousePosition);
    }
}
