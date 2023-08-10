using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    [SerializeField] private int LargeDebrisPoints;
    [SerializeField] private int SmallDebrisPoints;
    [SerializeField] private int gravityStrength;
    [SerializeField] private float secToWait;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObj = collision.gameObject;
        if (otherObj.CompareTag("DebrisL"))
        {
            ScoreManager.instance.UpdateScore(LargeDebrisPoints);
        }
        if (otherObj.CompareTag("DebrisS"))
        {
            ScoreManager.instance.UpdateScore(SmallDebrisPoints);
        }
        if (!otherObj.CompareTag("Player"))
        {
            StartCoroutine(destroyObjectCoroutine(otherObj));
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //Earth's gravity pulling down object
        other.attachedRigidbody.AddForce(Vector2.down * gravityStrength);
    }

    IEnumerator destroyObjectCoroutine(GameObject otherObj)
    {
        yield return new WaitForSeconds(secToWait);
        Destroy(otherObj);
    }
}
