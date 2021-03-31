using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_movement : MonoBehaviour
{
    
    Rigidbody2D rb, cameraRb;
    int speed = 10;
    bool invulnerable = false;
    GameObject barrier;
    GameObject camera;
    bool inMiddle = true;
    [HideInInspector]
    public bool isInMiniGame = true;
    bool canControl = true;

    void Start()
    {
        camera = GameObject.Find("MainCamera");
        cameraRb = camera.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        barrier = transform.GetChild(0).gameObject;
        rb.velocity = -transform.up * speed;
        gameObject.SetActive(false);

    }

    void FixedUpdate()
    {
        if (!isInMiniGame)
        {
            GetComponent<ShootBullets>().enabled = false;

            float horizontControls = Input.GetAxis("Horizontal");
            rb.velocity += new Vector2(horizontControls * .7f, 0);
            VelocityControl();
        }
        else
        {
            GetComponent<ShootBullets>().enabled = true;
            float vertControls = Input.GetAxis("Vertical");
            float horControls = Input.GetAxis("Horizontal");
            float vertSpeed;
            if (vertControls < 0)
            {
                vertSpeed = -cameraRb.velocity.y + 20;
            }
            else
            {
                vertSpeed = 20;
            }
            if(((vertControls != 0) || (horControls != 0)) && (canControl))
            {

                rb.velocity = new Vector2(horControls * 20, vertControls * vertSpeed);
            }
        }
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
        if ((!invulnerable) && (!inMiddle))
        {
            if ((gameObject.transform.position.y < camera.transform.position.y))
            {

                rb.velocity = new Vector2(rb.velocity.x, cameraRb.velocity.y + 2);
            }
            else if ((gameObject.transform.position.y > camera.transform.position.y))
            {
                rb.velocity = new Vector2(rb.velocity.x, cameraRb.velocity.y - 2);
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
        if (!invulnerable)
        {
            StartCoroutine(Invulnerable());
            rb.AddForce(Vector2.up * impulseVal, ForceMode2D.Impulse);

        }
    }
    public void KnockBack(Vector2 dir, float impulseVal)
    {
        StartCoroutine(CantControl());
        rb.velocity = dir * impulseVal;
       // rb.AddForce(dir * impulseVal, ForceMode2D.Impulse);
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
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        Destroy(gameObject);
    }
    
    IEnumerator CantControl()
    {
        canControl = false;
        yield return new WaitForSeconds(.5f);
        canControl = true;
    }
}
