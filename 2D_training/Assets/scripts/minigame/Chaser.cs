using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Entities
{
    Rigidbody2D rb;
    int speed = 7;
    int hp = 100;
    GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
        SeekForPlayer();
    }

    void Update()
    {
        if(player != null)
        {

            if(Vector3.Distance(player.transform.position, transform.position) < 20)
            {
                ChasePlayer();
                CancelInvoke();
            }
        }
        if(hp <= 0)
        {
            Die();
        }
    }

    void SeekForPlayer()
    {
        InvokeRepeating("SetRandomVelocity", 0, 2);
        
    }

    void SetRandomVelocity()
    {
        rb.velocity = new Vector2(Random.Range(-1f,  1f), Random.Range(-1f,  1f)) * speed;
    }
    void ChasePlayer()
    {
        Vector3 moveDir = (player.transform.position - transform.position).normalized;

        rb.velocity = moveDir * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {


            player.GetComponent<Player_movement>().KnockBack((Vector2)((player.transform.position - transform.position).normalized), 15);
            StartCoroutine(Cooldown());
        }
        else if(collision.tag == "friendly_bullet")
        {
            hp -= 33;
        }
    }
    IEnumerator Cooldown()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(1);
        rb.constraints &= ~RigidbodyConstraints2D.FreezePosition;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    void Die()
    {

        gameObject.SetActive(false);
    }
}
