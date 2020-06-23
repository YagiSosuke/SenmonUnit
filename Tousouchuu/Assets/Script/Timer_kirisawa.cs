using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_kirisawa : MonoBehaviour
{
    float countTime = 0;

    [SerializeField] private float Rimit = 180;//制限時間

    //　タイマー表示用テキスト
    private Text timerText;

    // Use this for initialization
    void Start()
    {
        timerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime; //スタートしてからの秒数を格納
        timerText.text = (Rimit - countTime).ToString("F2"); //小数2桁にして表示
    }
}