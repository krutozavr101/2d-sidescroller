﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRoom_spawner : MonoBehaviour
{
    [SerializeField]
    GameObject keyPrefab;
    [HideInInspector]
    public int quantity;
    Wall_spawner spawner;

    void Start()
    {
        keyPrefab = Resources.Load<GameObject>("prefabs/key");
        quantity = Random.Range(1, 4);
        spawner = GameObject.Find("minigame").GetComponent<Wall_spawner>();
        SpawnLockRoom();
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    void Update()
    {
        if(quantity == 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void SpawnLockRoom()
    {
        for (int i = 0;i < quantity; i++)
        {
            print(spawner.prevWallPos);
            GameObject key = Instantiate(keyPrefab, new Vector3(Random.Range(-13, 13), Random.Range(spawner.prevWallPos.y, gameObject.transform.position.y)), Quaternion.identity);
            
        }
        spawner.prevWallPos = gameObject.transform.position;
    }
    private void OnDisable()
    {
        FindObjectOfType<Wall_spawner>().curQuantity--;
    }
}
