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
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(value == 50)
            {
                StartCoroutine(HideCoin());
                Money_cnt.ChangeValue(value);

            }
            else
            {

            Money_cnt.ChangeValue(value);
            Destroy(gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        spawner.curQuantity--;
    }
    IEnumerator HideCoin()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(6);
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
