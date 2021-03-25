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
        else if(collision.tag == "coin")
        {
            Money_spawner.curQuantity--;
        }
        else if (collision.tag == "enemy")
        {
            Destroy(collision.gameObject);
            Enemy_spawner.curQuantity--;
        }
        else if (collision.tag == "bonus")
        {
            Destroy(collision.gameObject);
            Bonus_spawner.curQuantity--;
        }

    }
}
