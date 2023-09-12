using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBg : MonoBehaviour
{
    [SerializeField] private float speed; //Background move speed

    void Update()
    {
        Vector2 offset = new Vector2(speed/10 * Time.deltaTime, 0); //Moves background
        GetComponent<Renderer>().material.mainTextureOffset += offset; //Offset background
    }
}
