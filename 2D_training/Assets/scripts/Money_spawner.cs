using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money_spawner : Spawner
{

    [SerializeField]
    private GameObject greenCoinPrefab, redCoinPrefab, blueCoinPrefab, badCoinPrefab;
    [SerializeField]
    private int availableQuantity;

    private void Start()
    {
        delList.Add(delegate { SpawnGreenCoin(); });
        delList.Add(delegate { SpawnRedCoin(); });
        delList.Add(delegate { SpawnBlueCoin(); });
        InvokeRepeating("SpawnBadCoin", 5, 3);
    }

    void FixedUpdate()
    {
        if (curQuantity < availableQuantity)
        {
            StartCoroutine(SpawnRandomObject(0));
        }
    }

    protected override IEnumerator SpawnRandomObject(int objTypeCnt)
    {
        curQuantity++;
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        int i = Random.Range(0, 6);
        if (i < 3)
        {
            delList[0]();
        }
        else if ((i > 2) && (i < 5))
        {
            delList[1]();
        }
        else
        {
            delList[2]();
        }
    }

    void SpawnGreenCoin()
    {
        Vector3 pos = new Vector3(Random.Range(-15, 15), transform.position.y - Random.Range(40, 55), 0);

        GameObject coin = Instantiate(greenCoinPrefab, pos, Quaternion.identity);


    }
    void SpawnRedCoin()
    {
        Vector3 pos = new Vector3(Random.Range(-15, 15), transform.position.y - Random.Range(40, 55), 0);

        GameObject coin = Instantiate(redCoinPrefab, pos, Quaternion.identity);
    }
    void SpawnBlueCoin()
    {
        Vector3 pos = new Vector3(Random.Range(-15, 15), transform.position.y - Random.Range(40, 55), 0);

        GameObject coin = Instantiate(blueCoinPrefab, pos, Quaternion.identity);
    }
    void SpawnBadCoin()
    {
        Vector3 pos = new Vector3(Random.Range(-15, 15), transform.position.y - Random.Range(40, 55), 0);

        GameObject coin = Instantiate(badCoinPrefab, pos, Quaternion.identity);
    }
}
