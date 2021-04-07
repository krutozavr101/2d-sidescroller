using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_spawner : Spawner
{
    [SerializeField]
    GameObject wallPrefab, chaserPrefab, labirintWallPrefab, rotatingAxePrefab;
    float cd = 0;
    GameObject camera;
    int curMode ;
    bool spawnLockRoom = false;
    [HideInInspector ]
    public Vector3 prevWallPos = new Vector3(0, 0, 0);
    private void Start()
    {
        curQuantity = 0;
    }
    private void FixedUpdate()
    {
        if (curQuantity < 3)
        {
            SpawnWall();
        }
    }
    void SpawnWall()
    {
        curQuantity++;

        Vector3 pos = new Vector3(0, prevWallPos.y - 40, 0);
        GameObject wall = Instantiate(wallPrefab, pos, Quaternion.identity);
        GameObject brick =  wall.gameObject.transform.GetChild(Random.Range(0, wall.gameObject.transform.childCount)).gameObject;
        if (curMode == 1)
        {

            brick.AddComponent<LockRoom_spawner>();
            brick.GetComponent<LockRoom_spawner>().prevPos = prevWallPos;
        }
        else if(curMode == 2)
        {
            for( int i = 0; i < Random.Range(1, 3); i++)
            {
                GameObject chaser = Instantiate(chaserPrefab, new Vector3(Random.Range(-7, 7), Random.Range(prevWallPos.y -15 , wall.transform.position.y), 0), Quaternion.identity);
            }
            brick.AddComponent<Shootable_wall>();

        }
        else if(curMode == 3)
        {
            brick.SetActive(false);
            for (int i = 1;i < 5;i++)
            {
                Vector3 position = new Vector3(Random.Range(-5, 5), prevWallPos.y - 7 * i, 0);
                Instantiate(labirintWallPrefab, position, Quaternion.identity);

            }
        }
        else if(curMode == 4)
        {
            Instantiate(rotatingAxePrefab, new Vector3(0, prevWallPos.y - 20, 0), Quaternion.identity);
            brick.AddComponent<Shootable_wall>();


        }
        prevWallPos = pos;

        curMode = curMode % 4 + 1;
    }
    private void OnEnable()
    {
        camera = GameObject.Find("MainCamera");
        curMode = Random.Range(1, 5) ;
        prevWallPos = camera.transform.position;
        curQuantity = 0;
    }
}
