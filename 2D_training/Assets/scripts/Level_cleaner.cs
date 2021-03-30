using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_cleaner : MonoBehaviour
{
    Background_generation generator;

    void Start()
    {
        generator = FindObjectOfType<Background_generation>();

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "cloud")
        {
            generator.ReplaceCloud(collision.gameObject);

        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
