using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_movement : MonoBehaviour
{
    
    Rigidbody2D rb, cameraRb;
    int speed = 10;
    bool invulnerable = false;
    GameObject barrier, redBarrier;
    GameObject camera;
    bool inMiddle = true;
    [HideInInspector]
    public bool isInMiniGame = true;
    bool canControl = true;
    GameObject coinCnt;
    float horSpeed = .7f;
    float additionalVertSpeed;
    float resistToImpulse = 1;
    Vector3 baseScale;

    void Start()
    {
        camera = GameObject.Find("MainCamera");
        cameraRb = camera.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        barrier = transform.GetChild(0).gameObject;
        redBarrier = transform.GetChild(1).gameObject;
        rb.velocity = -transform.up * speed;
        gameObject.SetActive(false);
        coinCnt = GameObject.Find("final_results");
        baseScale = transform.localScale;

    }

    void FixedUpdate()
    {
        if(Input.GetKeyDown("k"))
        {
            Die();
        }
        if (!isInMiniGame)
        {
            GetComponent<ShootBullets>().enabled = false;

            float horizontControls = Input.GetAxis("Horizontal");
            rb.velocity += new Vector2(horizontControls * horSpeed, 0);
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

                rb.velocity = new Vector2(horControls * 34, vertControls * vertSpeed);
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

                rb.velocity = new Vector2(rb.velocity.x, cameraRb.velocity.y + 2 - additionalVertSpeed);
            }
            else if ((gameObject.transform.position.y > camera.transform.position.y))
            {
                rb.velocity = new Vector2(rb.velocity.x, cameraRb.velocity.y - 2 - additionalVertSpeed);
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
            rb.AddForce(Vector2.up * impulseVal * resistToImpulse, ForceMode2D.Impulse);

        }
    }
    public void KnockBack(Vector2 dir, float impulseVal)
    {
        StartCoroutine(CantControl());
        rb.velocity = dir * impulseVal;
    }

    public void SpeedBoost(int impulseVal)
    {
        if (!invulnerable)
        {
            StartCoroutine(Invulnerable());
            rb.AddForce(-Vector2.up * impulseVal * resistToImpulse, ForceMode2D.Impulse);

        }
    }
    public void Die()
    {
        coinCnt.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
        coinCnt.transform.GetChild(0).gameObject.SetActive(true);
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        Destroy(gameObject);
    }
    
    IEnumerator CantControl()
    {
        canControl = false;
        yield return new WaitForSeconds(.5f);
        canControl = true;
    }

    public void Boost()
    {
        StartCoroutine(MovementBoost(8f));
    }


    IEnumerator MovementBoost(float time)
    {
        redBarrier.SetActive(true);
        additionalVertSpeed += 1.2f;
        horSpeed += .3f;
        yield return new WaitForSeconds(time);

        additionalVertSpeed -= 1.2f;
        horSpeed -= .3f;
        redBarrier.SetActive(false);

    }

    public void BecomeBeeg()
    {
        BecomeNormal();
        StartCoroutine(Beeg());

    }
    public void BecomeSmall()
    {
        BecomeNormal();
        StartCoroutine(Small());
    }

    IEnumerator Beeg()
    {
        resistToImpulse = .45f;
        horSpeed -= .4f;
        transform.localScale = transform.localScale * 2.5f;
        yield return new WaitForSeconds(10);
        BecomeNormal();

    }
    IEnumerator Small()
    {
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        resistToImpulse = 1.4f;
        horSpeed += .4f;
        transform.localScale = transform.localScale / 1.5f;
        yield return new WaitForSeconds(10);
        BecomeNormal();
        
    }

    public void BecomeNormal()
    {
        StopCoroutine(Beeg());
        StopCoroutine(Small());
        resistToImpulse = 1;
        horSpeed = .7f;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        transform.localScale = baseScale;
    }
}
