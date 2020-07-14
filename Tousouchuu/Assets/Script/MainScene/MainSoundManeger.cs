using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//2020/07/14 メインシーン内のBGMを管理するスクリプト　桐澤


public class MainSoundManeger : MonoBehaviour
{
    public AudioClip Offtrak;
    public AudioClip OnTrak;
    AudioSource audioSource;

    public GameObject[] Enemys;

    private PatrolT[] EnemeysSC;

    private bool trak;
    private bool sw;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        trak = false;
        sw = false;

        EnemeysSC = new PatrolT[Enemys.Length];

        for (int i = 0;i < Enemys.Length; i++)
        {
            EnemeysSC[i] = Enemys[i].GetComponent<PatrolT>();
        }

        audioSource.clip = Offtrak;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        trak = false;
        
        for (int i = 0; i < EnemeysSC.Length; i++)
        {
             trak = EnemeysSC[i].GetTrak();
            if (trak) break; //trak = true で追跡されている
        }

        if (sw == false)
        {
            if (trak == true)
            {
                audioSource.clip = OnTrak;
                audioSource.Play();
                sw = true;
            }
        }
        else
        {
            if(trak == false)
            {
                audioSource.clip = Offtrak;
                audioSource.Play();
                sw = false;
            }
        }
    }
}
