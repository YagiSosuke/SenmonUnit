using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//作成者　桐澤　2020/6/30

public class TextOutTime : MonoBehaviour
{
    private float GoalTime;

    [SerializeField] GameObject Player;//Playernameを表示
    Text PlayerText;

    [SerializeField] GameObject Getaway;//逃げタ逃げたを表示
    Text GetawayText;

    [SerializeField] GameObject Goaltime;//逃げ切った秒数を表示
    Text timeText;

    [SerializeField] GameObject Rank;//ランクを表示
    Text RankText;

    [SerializeField] GameObject RankC;//ランク中身を表示
    Text RankTextC;



    // Start is called before the first frame update
    void Start()
    {
        GoalTime = Timer_kirisawa.GetTime();
        Invoke("Playertx", 1f);
        Invoke("Getawaytx", 2f);
        Invoke("Goaltx", 3f);
        Invoke("Ranktx", 4f);
        Invoke("RankCtx", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Playertx()
    {
        PlayerText = Player.GetComponent<Text>();
        PlayerText.text = "Player";
    }
    void Getawaytx()
    {
        GetawayText = Getaway.GetComponent<Text>();
        GetawayText.text = "逃げた!逃げた!夕飯はチーズだ!!";
    }
    void Goaltx()
    {
        timeText = Goaltime.GetComponent<Text>();
        timeText.text = "残り時間：" + GoalTime.ToString("F2") + "秒";
    }

    void Ranktx()
    {
        RankText = Rank.GetComponent<Text>();
        RankText.text = "ランク：";
    }
    void RankCtx()
    {
        RankTextC = RankC.GetComponent<Text>();
        if (GoalTime >= 0)
        {
            RankTextC.text = "ザコ";
        }
        if (GoalTime > 0)
        {
            RankTextC.text = "E";
        }
        if (GoalTime > 30)
        {
            RankTextC.text = "D";
        }
        if (GoalTime > 60)
        {
            RankTextC.text = "C";
        }
        if (GoalTime > 90)
        {
            RankTextC.text = "B";
        }
        if (GoalTime > 120)
        {
            RankTextC.text = "A";
        }
        if (GoalTime > 150)
        {
            RankTextC.text = "S";
        }
    }


    public void clicktitleON()
    {
        feadSC.fade("Title");//おまけ　タイトルに移動する
    }
}
