using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money_spawner : Spawner
{

    [SerializeField]
    private GameObject greenCoinPrefab;
    [SerializeField]
    private int availableQuantity;

    private void Start()
    {
        delList.Add(delegate { SpawnGreenCoin(); });
    }

    void FixedUpdate()
    {
        if (curQuantity < availableQuantity)
        {
            StartCoroutine(SpawnRandomObject(Random.Range(0, delList.Count)));
        }
    }

    void SpawnGreenCoin()
    {
        Vector3 pos = new Vector3(Random.Range(-15, 15), transform.position.y - Random.Range(40, 55), 0);

        GameObject bat = Instantiate(greenCoinPrefab, pos, Quaternion.identity);


    }
}
