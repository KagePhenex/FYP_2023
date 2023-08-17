using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

public class HarpoonBehaviour : MonoBehaviour
{
    public Transform caster, anchor;
    public bool debrisCollected;

    [SerializeField] private string[] tagsToCheck;
    [SerializeField] private float speed; //Speed of cable
    [SerializeField] private float range, stopRange; //Cable range and despawn range

    private Transform collidedWith;
    private LineRenderer cable;
    private bool hasCollided;

    private void Start()
    {
        cable = transform.Find("Cable").GetComponent<LineRenderer>();
    }

    private void Update()
    {
        cable.SetPosition(0, caster.position);
        cable.SetPosition(1, transform.position);

        //Check if we have impacted
        if (hasCollided)
        {
            //Rotate harpoon head
            Vector3 posDiff = caster.position - transform.position;
            float casterRot = Mathf.Atan2(posDiff.y, posDiff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, casterRot);

            //Destroy harpoon when it gets too close
            var dist = Vector2.Distance(transform.position, caster.position);
            if (dist < stopRange)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            var dist = Vector2.Distance(transform.position, caster.position);
            if (dist > range)
            {
                Collision(null);
            }
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (collidedWith) 
        { 
            collidedWith.transform.position = transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        //If harpoon has not collided and collides with large or small debris
        if (!hasCollided && tagsToCheck.Contains(collider.gameObject.tag))
        {
            Collision(collider);
        }
    }

    void Collision(Collider2D col)
    {
        //speed = -speed; //Reverse harpoon speed to return harpoon
        hasCollided = true;
        //If a debris is hit, harpoon positions becomes debris position
        if (col)
        {
            col.isTrigger = true;
            col.GetComponent<Rigidbody2D>().isKinematic = true;
            col.transform.rotation = new Quaternion(0, 0, 0, 0);
            col.transform.parent = caster.transform.parent.transform;
            transform.position = col.transform.position;
            collidedWith = col.transform;
            debrisCollected = true;
        }
    }
}
