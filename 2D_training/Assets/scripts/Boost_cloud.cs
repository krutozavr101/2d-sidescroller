using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_cloud : MonoBehaviour
{
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player_movement>().SpeedBoost(7);
        }
    }
}
