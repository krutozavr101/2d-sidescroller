using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    int value;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Money_cnt.ChangeValue(value);
            Money_spawner.curQuantity--;
            Destroy(gameObject);
        }
    }
}
