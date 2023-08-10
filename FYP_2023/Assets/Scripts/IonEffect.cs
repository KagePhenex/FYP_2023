using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonEffect : MonoBehaviour
{
    [SerializeField] private float ionForce = 5f;

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D otherRB = other.attachedRigidbody;
        Vector2 ionPos = transform.position;
        //Push object away from player
        otherRB.AddForce((otherRB.position - ionPos) * ionForce);
    }
}
