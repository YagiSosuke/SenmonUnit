using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
public void OnRetry()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name);
    }
}
