using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject cloudPrefab;
    [SerializeField]
    private int availableQuantity;
    [HideInInspector]
    public static   int curQuantity = 0;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (curQuantity < availableQuantity)
        {
            StartCoroutine(SpawnRandomBonus());
        }
    }
    IEnumerator SpawnRandomBonus()
    {
        curQuantity++;

        yield return new WaitForSeconds(Random.Range(0f, 3f));
        Vector3 pos = new Vector3(Random.Range(-15, 15), transform.position.y - Random.Range(40, 55), 0);
        SpawnCloud(pos);
    }
    void SpawnCloud(Vector3 pos)
    {
        GameObject bat = Instantiate(cloudPrefab, pos, Quaternion.identity);
        

    }
}
