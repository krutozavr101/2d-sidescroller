using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smallness : Entities
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
            collision.GetComponent<Player_movement>().BecomeSmall();
            Destroy(this);

        }
    }

    private void OnDestroy()
    {
        spawner.curQuantity--;
    }
}
