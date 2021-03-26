using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : Spawner
{
    [SerializeField]
    GameObject batPrefab;
    [SerializeField]
    private int availableQuantity;
    private void Start()
    {
        delList.Add(delegate { SpawnBat(); });
    }

    void FixedUpdate()
    {
        if(curQuantity < availableQuantity)
        {
            StartCoroutine(SpawnRandomObject( Random.Range(0, delList.Count)));
        }
    }
    
    void  SpawnBat()
    {
        Vector3 pos = new Vector3(Random.Range(-15, 15), transform.position.y - Random.Range(40, 55), 0);

        GameObject bat = Instantiate(batPrefab, pos, Quaternion.identity);
        
        if(Random.value > .5)
        {
            bat.GetComponent<Flying_enemy>().Flip();
        }
        StartCoroutine( EmergencyDestroy(bat));
    }

    
}
