using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_cleaner : MonoBehaviour
{
    Background_generation generator;
    Enemy_spawner spawner;
    void Start()
    {
        generator = FindObjectOfType<Background_generation>();
        spawner = FindObjectOfType<Enemy_spawner>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "cloud")
        {
            generator.ReplaceCloud(collision.gameObject);

        }
        else if (collision.tag == "enemy")
        {
            Destroy(collision.gameObject);
            spawner.curQuantity -= 1;
        }
    }
}
