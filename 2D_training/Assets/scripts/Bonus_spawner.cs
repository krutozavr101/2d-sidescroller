using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_spawner : Spawner
{

    [SerializeField]
    GameObject cloudPrefab;
    [SerializeField]
    private int availableQuantity;
    private void Start()
    {
        delList.Add(delegate { SpawnCloud(); });
    }

    void FixedUpdate()
    {
        if (curQuantity < availableQuantity)
        {
            StartCoroutine(SpawnRandomObject(Random.Range(0, delList.Count)));
        }
    }

    void SpawnCloud()
    {
        Vector3 pos = new Vector3(Random.Range(-15, 15), transform.position.y - Random.Range(40, 55), 0);

        GameObject bat = Instantiate(cloudPrefab, pos, Quaternion.identity);
        

    }
}
