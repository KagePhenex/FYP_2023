using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    public float thrustForce = 5.0f;
    public float overheat = 0f;
    public float maxOverheat = 5.0f;
    public float overheatRate = 0.5f;
    public OverheatBar overheatBar;
    public GameObject overheatTxt;

    private Vector2 moveVec2;
    private Rigidbody2D rb;
    private bool isMoving;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        overheatBar.setMaxOverheat(maxOverheat);
    }

    void FixedUpdate()
    {
        rb.AddForce(moveVec2 * thrustForce);

        if (overheat < maxOverheat)
        {
            if(moveVec2 != new Vector2(0, 0))
            {
                overheat += overheatRate * Time.deltaTime;
                overheatBar.setOverheat(overheat);
                Debug.Log("Overheat: " + overheat);
            }
            else
            {
                checkMoving();
            }
        }
        if (overheat >= maxOverheat)
        {
            Debug.Log("Overheated");
            overheatTxt.SetActive(true);
            moveVec2 = new Vector2(0, 0);
            StartCoroutine(cooldownCoroutine());
        }

        overheatBar.setOverheat(overheat);
    }
    void OnMove(InputValue moveValue) 
    {
        moveVec2 = moveValue.Get<Vector2>();
    }
    void checkMoving()
    {
        if (overheat != 0f)
        {
            overheat -= (overheatRate/3f) * Time.deltaTime;
        }
    }
    IEnumerator cooldownCoroutine()
    {
        yield return new WaitForSeconds(5);
        overheat = 0f;
        overheatTxt.SetActive(false);
    }
}

