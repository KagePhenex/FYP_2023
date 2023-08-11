using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class hook : MonoBehaviour
{
    public string[] tagsToCheck;
    //Force applied to nova bomb upon spawn
    public float speed, returnSpeed;
    public Transform caster, collidedWith;

    //Private variables
    [HideInInspector]
    private LineRenderer line;
    private bool hasCollided;

    private void Start()
    {
        line = transform.Find("Line").GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (caster)
        {
            line.SetPosition(0, caster.position);
            line.SetPosition(1, transform.position);
            //Check if we have impacted
            if (hasCollided)
            {
                transform.LookAt(caster);
            }

            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (collidedWith) 
            { 
                collidedWith.transform.position = transform.position; 
            }
        }
        else 
        { 
            Destroy(gameObject); 
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        //Here add as many checks as you want for your nova bomb's collision
        if (!hasCollided && tagsToCheck.Contains(collider.gameObject.tag))
        {
            Collision(collider);
        }
    }

    void Collision(Collider2D col)
    {
        speed = returnSpeed;
        //Stop movement
        hasCollided = true;
        if (col)
        {
            col.isTrigger = true;
            transform.position = col.transform.position;
            collidedWith = col.transform;
        }
    }
}
