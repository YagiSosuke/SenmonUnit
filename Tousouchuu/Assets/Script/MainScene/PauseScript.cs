using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*Main の ポーズ画面に関するスクリプト群*/

public class PauseScript : MonoBehaviour
{
    GameObject PauseWindow;    //ポーズウィンドウ

    public bool PauseF;        //ポーズになったフラグ(true = ポーズ、false = 再開)

    // Start is called before the first frame update
    void Start()
    {
        PauseWindow = GameObject.Find("PauseWindow");       //ポーズウィンドウを変数に格納
        PauseWindow.SetActive(false);        //ポーズウィンドウを非アクティブにする
        PauseF = false;     //ゲームを動かす
    }

    // Update is called once per frame
    void Update()
    {
        //Escキーを押したらポーズ
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseF = true;
        }

        //ポーズになった時
        if (PauseF)
        {
            Time.timeScale = 0f;        //ゲーム上の時間を止める（ポーズ）
            PauseWindow.SetActive(true);        //ポーズウィンドウをアクティブにする
        }
        //ゲームが動いているとき
        else
        {
            Time.timeScale = 1f;        //ゲーム上の時間を動かす(再開）
            PauseWindow.SetActive(false);        //ポーズウィンドウを非アクティブにする
        }
    }



    //ポーズボタンを押したら
    public void PauseButtonClick()
    {
        PauseF = true;
    }

    //ポーズ - ゲームボタンを押したら
    public void GoGameButtonClick()
    {
        PauseF = false;
    }
        
    //ポーズ - タイトルボタンを押したら
    public void GoTitleButtonClick()
    {
        Time.timeScale = 1f;        //ゲーム上の時間を動かす(リスタート）
        feadSC.fade("Title");
    }
}
