using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_spawner : Spawner
{

    [SerializeField]
    GameObject cloudPrefab, moveBoostPrefab, beegYoshiPrefab, smallnessPrefab;
    [SerializeField]
    private int availableQuantity;
    private void Start()
    {
        delList.Add(delegate { SpawnCloud(); });
        delList.Add(delegate { SpawnMoveBoost(); });
        delList.Add(delegate { SpawnBeegYoshi(); });
        delList.Add(delegate { SpawnSmallness(); });

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
        if (i == 3)
        {
            delList[1]();
        }
        else if(i == 4)
        {
            delList[2]();
        }
        else if(i == 5)
        {
            delList[3]();
        }
        else
        {
            delList[0]();
        }

    }
    void SpawnCloud()
    {
        Vector3 pos = new Vector3(Random.Range(-15, 15), transform.position.y - Random.Range(40, 55), 0);

        GameObject cloud = Instantiate(cloudPrefab, pos, Quaternion.identity);
        

    }
    void SpawnMoveBoost()
    {
        Vector3 pos = new Vector3(Random.Range(-13, 13), transform.position.y - Random.Range(40, 55), 0);

        GameObject boost = Instantiate(moveBoostPrefab, pos, Quaternion.identity);
        

    }
    void SpawnBeegYoshi()
    {
        Vector3 pos = new Vector3(Random.Range(-13, 13), transform.position.y - Random.Range(40, 55), 0);

        GameObject beeg = Instantiate(beegYoshiPrefab, pos, Quaternion.identity);
        

    }
    void SpawnSmallness()
    {
        Vector3 pos = new Vector3(Random.Range(-13, 13), transform.position.y - Random.Range(40, 55), 0);

        GameObject small = Instantiate(smallnessPrefab, pos, Quaternion.identity);
        

    }
}
