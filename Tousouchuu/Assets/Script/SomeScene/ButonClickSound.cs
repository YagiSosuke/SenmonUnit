using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*ボタンをクリックしたときの音のスクリプト*/

public class ButonClickSound : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip Correct;
    
    public void SoundPlay()
    {
        audio.PlayOneShot(Correct);
    }
}
