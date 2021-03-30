using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Money_spawner spawner;
    [SerializeField]
    int value;
    private void Start()
    {
        spawner = FindObjectOfType<Money_spawner>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Money_cnt.ChangeValue(value);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        spawner.curQuantity--;
    }
}
