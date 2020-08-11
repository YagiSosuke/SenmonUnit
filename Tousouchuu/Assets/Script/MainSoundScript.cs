using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSoundScript : MonoBehaviour{
    public bool DontDestroyEnabled = true;

    // Use this for initilization
    void Start(){
        if (DontDestroyEnabled) {
            DontDestroyOnLoad(this);
                }
    }

void LoadScene()
    {
        SceneManager.LoadScene("Tutorial1");
    }
}
