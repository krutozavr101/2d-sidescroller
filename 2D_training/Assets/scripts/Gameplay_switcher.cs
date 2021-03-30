using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay_switcher : MonoBehaviour
{

    GameObject player;
    Rigidbody2D playerRb;
    [SerializeField]
    GameObject minigame, basegame;

    void Start()
    {
        player = GameObject.Find("player");
        playerRb = player.GetComponent<Rigidbody2D>();
        InvokeRepeating("ChangeGamePlay", 0, 10);
    }

    void Update()
    {
        
    }

    void ChangeGamePlay()
    {
        Entities obj = FindObjectOfType<Entities>();
        while (obj != null)
        {
            obj.Die();
            obj = FindObjectOfType<Entities>();
        }
        player.GetComponent<Player_movement>().isInMiniGame = !player.GetComponent<Player_movement>().isInMiniGame ;
        if(player.GetComponent<Player_movement>().isInMiniGame)
        {
            minigame.SetActive(true);
            basegame.SetActive(false);
        }
        else
        {
            minigame.SetActive(false);
            basegame.SetActive(true);
        }
        
    }
}
