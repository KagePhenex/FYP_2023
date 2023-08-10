using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentLook: MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;

    void Start()
    {
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDir = mousePos - transform.position;
        float angle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //Apply rotation to equipment
    }
}
