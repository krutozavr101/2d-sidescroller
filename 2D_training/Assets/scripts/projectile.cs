using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : Entities
{
    Enemy_spawner spawner;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity =  Vector2.up * 10;
        spawner = FindObjectOfType<Enemy_spawner>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player_movement>().SlowDown(7);
        }
    }
    private void OnDestroy()
    {

        spawner.curQuantity--;
    }
}
