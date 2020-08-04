using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy") 
        {
            HPScript.ReceiveDamage();
            if(HPScript.HP == 0)
                SceneManager.LoadScene("Losing");
        }
    
    }
}
