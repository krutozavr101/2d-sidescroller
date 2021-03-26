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
    bool inMiddle = true;

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
        VelocityControl();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "middle_zone")
        {
            inMiddle = true;
        }
        if (!invulnerable)
        {
            if (collision.tag == "middle_zone")
            {
                rb.velocity = new Vector2(rb.velocity.x, cameraRb.velocity.y);
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "middle_zone")
        {
            inMiddle = false;
        }
    }

    void VelocityControl()
    {
        if((!invulnerable) && (!inMiddle))
        {
            if((gameObject.transform.position.y < camera.transform.position.y))
            {
                print("slow");
                rb.velocity = new Vector2(rb.velocity.x, cameraRb.velocity.y + 2);
            }
            else if((gameObject.transform.position.y > camera.transform.position.y))
            {
                print("boost");
                rb.velocity = new Vector2(rb.velocity.x, cameraRb.velocity.y - 3);
            }

        }
        
    }
    IEnumerator Invulnerable()
    {
        invulnerable = true;
        barrier.SetActive(true);
        yield return new WaitForSeconds(1);
        barrier.SetActive(false);
        invulnerable = false;
        
    }
    public void SlowDown(int impulseVal)
    {
        if(!invulnerable)
        {
            StartCoroutine(Invulnerable());
            rb.AddForce(Vector2.up * impulseVal, ForceMode2D.Impulse);

        }
    }

    public void SpeedBoost(int impulseVal)
    {
        if (!invulnerable)
        {
            StartCoroutine(Invulnerable());
            rb.AddForce(-Vector2.up * impulseVal, ForceMode2D.Impulse);

        }
    }
    public void Die()
    {
        gameObject.SetActive(false);
    }
}
