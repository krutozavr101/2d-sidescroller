using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money_spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject greenCoinPrefab;
    [SerializeField]
    private int availableQuantity;
    [HideInInspector]
    public static int curQuantity = 0;

    void FixedUpdate()
    {
        if (curQuantity < availableQuantity)
        {
            StartCoroutine(SpawnRandomCoin());
        }
    }
    IEnumerator SpawnRandomCoin()
    {
        curQuantity++;

        yield return new WaitForSeconds(Random.Range(0f, 3f));
        Vector3 pos = new Vector3(Random.Range(-15, 15), transform.position.y - Random.Range(40, 55), 0);
        SpawnGreenCoin(pos);
    }
    void SpawnGreenCoin(Vector3 pos)
    {
        GameObject bat = Instantiate(greenCoinPrefab, pos, Quaternion.identity);


    }
}
