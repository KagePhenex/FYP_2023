using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonBehaviour : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private LineRenderer lineRenderer;
    private Camera cam;

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(lineRenderer.positionCount > 0)
        {
            lineRenderer.SetPosition(1, transform.position);
            lineRenderer.SetPosition(0, mousePos);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            var raycast = Physics2D.Raycast(cam.transform.position, mousePos, Mathf.Infinity, layerMask);
            lineRenderer.positionCount = 2;
            //Debug.Log(raycast.transform.tag);
        }
    }
}
