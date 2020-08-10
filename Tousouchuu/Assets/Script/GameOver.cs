using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public HPScript HPscript;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy") 
        {
            HPscript.ReceiveDamage();
            if(HPScript.HP == 0)
                SceneManager.LoadScene("Losing");
        }
    
    }
}
