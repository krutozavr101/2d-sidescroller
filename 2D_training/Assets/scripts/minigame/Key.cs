using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Entities
{
    LockRoom_spawner lockDoor;
    void Start()
    {
         lockDoor = FindObjectOfType<LockRoom_spawner>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            lockDoor.quantity--;
            gameObject.SetActive(false);
        }
    }
}
