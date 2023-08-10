using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothness = 0.5f;

    private GameObject player;
    private Vector3 velocity;
    private Vector3 offset;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerPos = player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, playerPos, ref velocity, smoothness);
    }
}
