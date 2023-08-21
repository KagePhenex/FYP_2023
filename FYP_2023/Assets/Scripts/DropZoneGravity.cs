using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneGravity : MonoBehaviour
{
    [SerializeField] private float gravityStrength; //Strength of gravity
    [SerializeField] private float secToWait; //Seconds to wait before killing player
    [SerializeField] private GameObject player;

    private void OnTriggerStay2D(Collider2D other)
    {
        //Earth's gravity pulling down object
        other.attachedRigidbody.AddForce(Vector2.down * gravityStrength);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraFollow>().enabled = false;
            player.GetComponent<ShipController>().enabled = false;
            StartCoroutine(killPlayerCoroutine());
        }
    }
    IEnumerator killPlayerCoroutine()
    {
        yield return new WaitForSeconds(secToWait);
        HealthManager.instance.updateHealth(0);
    }
}
