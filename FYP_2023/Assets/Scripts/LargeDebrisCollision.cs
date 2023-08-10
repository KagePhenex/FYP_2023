using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeDebrisCollision : MonoBehaviour
{
    [SerializeField] private float collisionVelocity;
    [SerializeField] private List<GameObject> debrisFrag = new List<GameObject>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 fragSpawnPos = transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);

        if (collision.collider.tag == "DebrisL" && collision.relativeVelocity.magnitude >= collisionVelocity)
        {
            for (int i = 0; i < debrisFrag.Count; i++)
            {
                Instantiate(debrisFrag[i], fragSpawnPos, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
