using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    Rigidbody2D rb, cameraRb;
    int speed = 10;
    bool invulnerable = false;
    GameObject barrier;
    GameObject camera;

    void Start()
    {
        camera = GameObject.Find("MainCamera");
        cameraRb = camera.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        barrier = transform.GetChild(0).gameObject;
        rb.velocity = -transform.up * speed;

    }

    void FixedUpdate()
    {
        float horizontControls = Input.GetAxis("Horizontal");
        rb.velocity += new Vector2(horizontControls * .7f, 0);
        if((rb.velocity.y <= cameraRb.velocity.y) && (gameObject.transform.position.y <= camera.transform.position.y))
        {

            rb.velocity = new Vector2(rb.velocity.x, cameraRb.velocity.y);

        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public void SlowDown(int impulseVal)
    {
        if(!invulnerable)
        {
            StartCoroutine(Invulnerable());
            rb.AddForce(Vector2.up * impulseVal, ForceMode2D.Impulse);
            

        }
    }

    IEnumerator Invulnerable()
    {
        invulnerable = true;
        barrier.SetActive(true);
        yield return new WaitForSeconds(1);
        barrier.SetActive(false);
        invulnerable = false;
        if(rb.velocity.y > cameraRb.velocity.y)
        {
            rb.velocity = new Vector2(rb.velocity.x, cameraRb.velocity.y - 3);

        }
    }
}
