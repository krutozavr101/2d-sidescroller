using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_generation : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> cloudAssets;
     List<GameObject> clouds = new List<GameObject>();

    void Start()
    {
        GenerateClouds();
    }

    void FixedUpdate()
    {
       
    }
    void GenerateClouds()
    {

        for (int i = 0; i <= 31; i++)
        {
            GameObject cloud = Instantiate(cloudAssets[Random.Range(0, cloudAssets.Count)], new Vector3(Random.Range(-13, 13), transform.position.y - Random.Range(-5, 5), 0), Quaternion.identity);

            clouds.Add(cloud);
        }
        
    }
    public void ReplaceCloud(GameObject deletedCloud)
    {
        GameObject cloud = Instantiate(cloudAssets[Random.Range(0, cloudAssets.Count)], new Vector3(Random.Range(-13, 13), transform.position.y - Random.Range(5, 10), 0), Quaternion.identity);

        clouds[clouds.LastIndexOf(deletedCloud)] = cloud;
        Destroy(deletedCloud);
    }
}
