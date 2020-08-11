using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextTutorial : MonoBehaviour
{
    public void LoadingNewScene()
    {
        feadSC.fade("Tutorial2");
    }
}
