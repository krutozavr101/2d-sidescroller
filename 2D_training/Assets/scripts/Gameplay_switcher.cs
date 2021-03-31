using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gameplay_switcher : MonoBehaviour
{

    GameObject player;
    Rigidbody2D playerRb;
    [SerializeField]
    GameObject minigame, basegame;

    void Awake()
    {
        player = GameObject.Find("player");
        playerRb = player.GetComponent<Rigidbody2D>();
        InvokeRepeating("ChangeGamePlay", 20, 20);
        GetComponent<Camera_script>().enabled = true;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            if(player != null)
            {

            player.SetActive(true);
            }
        }

    }

    void ChangeGamePlay()
    {

        foreach(Entities obj in FindObjectsOfType<Entities>())
        {

            obj.Die();
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
