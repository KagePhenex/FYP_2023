using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] debris; //Debris Array
    [SerializeField] private float numToSpawn, chanceToSpawn, avoidSpawn; //Number and Chance to spawn, and distance to avoid spawn

    void Start()
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            Vector2 randomRange = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 8f));
            int randomChance = Random.Range(0, 100);

            //Spawn debris if distance is bigger than avoidSpawn
            if (Vector2.Distance(new Vector2(0, 0), randomRange) > avoidSpawn)
            {
                //Spawn based on chance
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
