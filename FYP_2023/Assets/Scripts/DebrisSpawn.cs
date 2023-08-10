using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawn : MonoBehaviour
{
    [SerializeField] private GameObject debris1;
    [SerializeField] private GameObject debris2;
    [SerializeField] private float numToSpawn;
    [SerializeField] private float chanceToSpawn;

    void Start()
    {

        //Spawn debris
        for (int i = 0; i < numToSpawn; i++)
        {
            Vector2 randomRange = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 8f));

            int randomChance = Random.Range(0, 100);
            if (randomChance < chanceToSpawn)
            {
                Instantiate(debris1, randomRange, Quaternion.identity);
            }
            if (randomChance > chanceToSpawn)
            {
                Instantiate(debris2, randomRange, Quaternion.identity);
            }
        }
    }
}
