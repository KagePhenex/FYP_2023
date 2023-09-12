using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothness = 0.5f;

    private GameObject player;
    private Vector3 velocity, offset;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 playerPos = player.transform.position + offset; //Offset camera Z pos
        transform.position = Vector3.SmoothDamp(transform.position, playerPos, ref velocity, smoothness); //Apply dampened follow effect
    }
}
