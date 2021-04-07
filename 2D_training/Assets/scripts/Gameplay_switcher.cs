using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gameplay_switcher : MonoBehaviour
{

    GameObject player;
    Camera_script camera;
    [SerializeField]
    GameObject minigame, basegame;

    void Awake()
    {
        camera = FindObjectOfType<Camera_script>();
        player = GameObject.Find("player");
        InvokeRepeating("ChangeGamePlay", 25, 25);
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
            player.GetComponent<Player_movement>().BecomeNormal();
            minigame.SetActive(true);
            basegame.SetActive(false);
            camera.rb.velocity = new Vector2(camera.rb.velocity.x, camera.rb.velocity.y * .7f);
        }
        else
        {
            camera.rb.velocity = new Vector2(camera.rb.velocity.x, camera.rb.velocity.y * 1.3f);
            minigame.SetActive(false);
            basegame.SetActive(true);
        }
        
    }
}
