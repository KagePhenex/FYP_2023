using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

public class HarpoonBehaviour : MonoBehaviour
{
    public Transform caster; //Transform where cable starts
    public bool debrisCollected; //Check if any debris is collected

    [SerializeField] private string[] tagsToCheck; //Tags to check
    [SerializeField] private float speed; //Speed of cable
    [SerializeField] private float range, stopRange; //Cable range and despawn range

    private Transform collidedWith; //Collided object
    private LineRenderer cable; //Cable line
    private bool hasCollided; //Check if collided

    private void Start()
    {
        cable = transform.Find("Cable").GetComponent<LineRenderer>();
    }

    private void Update()
    {
        //Set cable start and end points
        cable.SetPosition(0, caster.position);
        cable.SetPosition(1, transform.position);

        //Check if impacted
        if (hasCollided)
        {
            //Rotate harpoon head
            Vector3 posDiff = caster.position - transform.position;
            float casterRot = Mathf.Atan2(posDiff.y, posDiff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, casterRot);

            //Destroy harpoon when it gets too close to 
            var dist = Vector2.Distance(transform.position, caster.position);
            if (dist < stopRange)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            //Return harpoon if out of range
            var dist = Vector2.Distance(transform.position, caster.position);
            if (dist > range)
            {
                Collision(null);
            }
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime); //Move harpoon
        //If collided with a debris, set debris position to harpoon position (returns to ship with the harpoon)
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
            SFXManager.instance.playHarpoonHit();
            col.isTrigger = true; //Debris collider set to trigger 
            col.GetComponent<Rigidbody2D>().isKinematic = true; //Debris now moves with ship
            col.transform.parent = caster.transform.parent.transform; //Parent Debris to Harpoon Gun

            transform.position = col.transform.position;
            collidedWith = col.transform;
            debrisCollected = true;
        }
    }
}
