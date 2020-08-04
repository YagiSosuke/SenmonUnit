using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_kirisawa : MonoBehaviour
{
    private float countTime;

    [SerializeField] private float Rimit = 180;//制限時間

    static float RemainingTime;

    //　タイマー表示用テキスト
    private Text timerText;

    // Use this for initialization
    void Start()
    {
        timerText = GetComponentInChildren<Text>();
        countTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime; //スタートしてからの秒数を格納
        RemainingTime = Rimit - countTime;
        timerText.text = RemainingTime.ToString("F2") + "秒"; //小数2桁にして表示
    }

    public static float  GetTime()
    {
        return RemainingTime;
    }
}