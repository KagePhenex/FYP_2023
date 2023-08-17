using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] debris;
    [SerializeField] private float numToSpawn, chanceToSpawn; //Number and Chance to spawn

    void Start()
    {
        //Spawn debris
        for (int i = 0; i < numToSpawn; i++)
        {
            Vector2 randomRange = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 8f));
            int randomChance = Random.Range(0, 100);

            if (Vector2.Distance(new Vector2(0, 0), randomRange) > 0.2f)
            {
                if (randomChance < chanceToSpawn)
                {
                    Instantiate(debris[0], randomRange, Quaternion.identity);
                }
                else if (randomChance > chanceToSpawn)
                {
                    Instantiate(debris[1], randomRange, Quaternion.identity);
                }
            }
        }
    }
}
