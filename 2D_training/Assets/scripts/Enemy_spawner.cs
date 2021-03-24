using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    [SerializeField]
    GameObject batPrefab;
    [SerializeField]
    private int availableQuantity;
    [HideInInspector]
    public int curQuantity = 0;
    void Start()
    {
        
    }

    void Update()
    {
        if(curQuantity < availableQuantity)
        {
            StartCoroutine(SpawnRandomEnemy());
        }
    }
    IEnumerator SpawnRandomEnemy()
    {
        curQuantity++;

        yield return new WaitForSeconds(Random.Range(0f, 3f));
        Vector3 pos = new Vector3(Random.Range(-12, 12), transform.position.y - Random.Range(40, 55), 0);
        SpawnBat(pos);
    }
    void SpawnBat(Vector3 pos)
    {
        GameObject bat = Instantiate(batPrefab, pos, Quaternion.identity);
       if(Random.value > .5)
       {
        bat.GetComponent<Flying_enemy>().Flip();
       }
        
    }
}
