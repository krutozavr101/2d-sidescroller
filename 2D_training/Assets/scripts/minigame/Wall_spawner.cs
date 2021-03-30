using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_spawner : Spawner
{
    [SerializeField]
    GameObject wallPrefab, chaserPrefab;
    float cd = 0;
    GameObject camera;
    bool spawnLockRoom = false;
    [HideInInspector ]
    public Vector3 prevWallPos = new Vector3(0, 0, 0);
    private void Start()
    {
        curQuantity = 0;
        camera = GameObject.Find("MainCamera");
    }
    private void FixedUpdate()
    {
        if (curQuantity < 1)
        {
            SpawnWall();
        }
    }
    void SpawnWall()
    {
        curQuantity++;
        Vector3 pos = new Vector3(0, camera.transform.position.y - 40, 0);
        GameObject wall = Instantiate(wallPrefab, pos, Quaternion.identity);
        GameObject brick =  wall.gameObject.transform.GetChild(Random.Range(0, wall.gameObject.transform.childCount)).gameObject;
        if (spawnLockRoom)
        {

            brick.gameObject.AddComponent<LockRoom_spawner>();
        }
        else
        {
            GameObject chaser = Instantiate(chaserPrefab, new Vector3(Random.Range(-5, 5), Random.Range(prevWallPos.y, wall.transform.position.y), 0), Quaternion.identity);
            brick.gameObject.AddComponent<Shootable_wall>();

        }
        spawnLockRoom = !spawnLockRoom;
        
    }
    private void OnEnable()
    {
        spawnLockRoom = false;
    }
}
