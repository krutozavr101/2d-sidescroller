using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = -Vector2.up * 40;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "wall") || (collision.tag == "enemy"))
        {
            Destroy(gameObject);
        }
    }
}
