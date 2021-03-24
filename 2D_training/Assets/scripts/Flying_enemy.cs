using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying_enemy : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    [SerializeField]
    bool facingRight = true;
    int speed = 15;
    void Start()
    {
        player = GameObject.Find("player");
        rb = GetComponent<Rigidbody2D>();

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
        if (collision.tag == "Player")
        {
            player.GetComponent<Player_movement>().SlowDown(7);
        }
        else  if (collision.gameObject.GetComponentInChildren<BoxCollider2D>() != null)
        {
            if (collision.gameObject.GetComponentInChildren<BoxCollider2D>().tag == "flip")
            {
                Flip();
            }
        }
        
        
        
        
    }
    public void Flip()
    {
        gameObject.transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
        
    }

    
}
