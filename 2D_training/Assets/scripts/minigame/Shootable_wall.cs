using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable_wall : MonoBehaviour
{
    int hp = 100;
    Wall_spawner spawner;
    private void Update()
    {
        if(hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        spawner = FindObjectOfType<Wall_spawner>();
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "friendly_bullet")
        {
            hp -= 40;
        }
    }
    private void OnDisable()
    {
        spawner.curQuantity--;
    }


}
