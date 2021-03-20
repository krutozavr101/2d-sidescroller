using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : MonoBehaviour
{
    Background_generation generator;
    void Start()
    {
        generator = GetComponent<Background_generation>();
    }

    void Update()
    {
        
    }
    /// <summary>
    /// Cleans level behind screen
    /// </summary>
    /// <param name="cleaner"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        generator.ReplaceCloud(collision.gameObject);
    }
}
