using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : MonoBehaviour
{
    Background_generation generator;
    Rigidbody2D rb;
    int speed = 10;
    void Start()
    {
        generator = GetComponent<Background_generation>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * speed;
    }

    void Update()
    {
        
    }

}
