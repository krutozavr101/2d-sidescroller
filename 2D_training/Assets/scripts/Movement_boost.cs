using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_boost : Entities
{
    Bonus_spawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<Bonus_spawner>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player_movement>().Boost();
        }
    }

    private void OnDestroy()
    {
        spawner.curQuantity--;
    }
}
