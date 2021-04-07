using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_labirint_wall : MonoBehaviour
{

    Rigidbody2D rb;
    bool facingRight;
    int speed = 15;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = Random.Range(0, 2) == 1;
    }

    void Update()
    {
        if (facingRight)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player_movement>().KnockBack((rb.velocity + new Vector2(Random.Range(-5, 5), 0)).normalized, 20);
        }
        if (collision.gameObject.GetComponentInChildren<BoxCollider2D>() != null)
        {
            if (collision.gameObject.GetComponentInChildren<BoxCollider2D>().tag == "flip")
            {
                Flip();
            }
        }




    }
    public void Flip()
    {
        facingRight = !facingRight;

    }
}
