using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRoom_spawner : MonoBehaviour
{
    [SerializeField]
    GameObject keyPrefab;
    [HideInInspector]
    public int quantity;
    Wall_spawner spawner;
    public Vector3 prevPos;

    void Start()
    {
        spawner = GameObject.Find("minigame").GetComponent<Wall_spawner>();
        keyPrefab = Resources.Load<GameObject>("prefabs/key");
        quantity = Random.Range(1, 4);
        SpawnLockRoom();
        GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f);
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

            GameObject key = Instantiate(keyPrefab, new Vector3(Random.Range(-13, 13), Random.Range(prevPos.y - 10, gameObject.transform.position.y + 3)), Quaternion.identity);
            
        }

    }
    private void OnDisable()
    {
        if(FindObjectOfType<Wall_spawner>() != null)
        {

        FindObjectOfType<Wall_spawner>().curQuantity--;
        }
    }
}
