using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating_axe : Entities
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -6f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {


            collision.GetComponent<Player_movement>().KnockBack((Vector2)((collision.transform.position - transform.position).normalized), 30);
        }

    }

}
