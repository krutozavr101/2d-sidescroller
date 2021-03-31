using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_manager : MonoBehaviour
{
    void Start()
    {
        //Time.timeScale = 0;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            PlayTheGame();
        }
    }

    void PlayTheGame()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(1);
    }
}
