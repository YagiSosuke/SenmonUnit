using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManegment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "TItle")
        {
            if (Input.GetKey(KeyCode.KeypadEnter))
            {
                feadSC.fade("Main");
            }
            if (Input.GetKey(KeyCode.C))
            {
                feadSC.fade("Credit");
            }
        }


        if (SceneManager.GetActiveScene().name == "Main")
        {
            if (Input.GetKey(KeyCode.KeypadEnter))
            {
                feadSC.fade("Score");
            }
        }


        if (SceneManager.GetActiveScene().name == "Score")
        {
            if (Input.GetKey(KeyCode.KeypadEnter))
            {
                feadSC.fade("TItle");
            }
        }


        if (SceneManager.GetActiveScene().name == "Credit")
        {
            if (Input.GetKey(KeyCode.KeypadEnter))
            {
                feadSC.fade("TItle");
            }
        }
    }
}
