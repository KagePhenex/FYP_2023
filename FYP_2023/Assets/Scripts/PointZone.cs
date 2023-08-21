using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointZone : MonoBehaviour
{
    [SerializeField] private int LargeDebrisPoints, SmallDebrisPoints; //Points
    [SerializeField] private float secToWait; //Seconds to wait before destroying object

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObj = collision.gameObject;
        if (otherObj.CompareTag("DebrisL"))
        {
            StartCoroutine(destroyObjectCoroutine(otherObj));
            ScoreManager.instance.UpdateScore(LargeDebrisPoints);
        }
        if (otherObj.CompareTag("DebrisS"))
        {
            StartCoroutine(destroyObjectCoroutine(otherObj));
            ScoreManager.instance.UpdateScore(SmallDebrisPoints);
        }
    }

    IEnumerator destroyObjectCoroutine(GameObject otherObj)
    {
        yield return new WaitForSeconds(secToWait);
        Destroy(otherObj);
    }
}
