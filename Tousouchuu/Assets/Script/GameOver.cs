using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   void Start()
    {
 
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cat") 
        {
            SceneManager.LoadScene("Losing");
        }
    
    }
}
