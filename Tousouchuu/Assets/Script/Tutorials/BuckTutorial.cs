using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuckTutorial : MonoBehaviour
{
    public void LoadingNewScene()
    {
        SceneManager.LoadScene("Tutorial1");
    }
}