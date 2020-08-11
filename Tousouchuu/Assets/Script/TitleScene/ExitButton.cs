using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*タイトル - ゲーム終了動作*/

public class ExitButton : MonoBehaviour
{
    [SerializeField] GameObject ExitPanel;      //ゲーム終了の確認パネル
    Vector3 Panel_pos;          //ExitPanelは最初は邪魔にならないよう移動させてある、位置をセットしてあげる
    public bool ExitF;          //ExitPanelが展開されているかを見るフラグ(展開されている:true 展開されていない:false)

    GameObject STButton;        //スタートボタン
    GameObject YESButton;       //終了 - はいボタン
    GameObject NOButton;       //終了 - いいえボタン

    ButtonFirstActive STFirstActive;        //スタートボタンのスクリプト
    ButtonFirstActive YESFirstActive;       //終了 - はいボタンのスクリプト

    void Start()
    {
        ExitPanel = GameObject.Find("ExitCheckPanel");          //ExitPanel変数に格納
        Panel_pos = new Vector3(0, 0, 0);                       //初期位置を設定
        ExitF = false;                                          //ExitPanelが展開されていない
        
        STButton = GameObject.Find("StartButton");   //スタートボタンを格納
        YESButton = GameObject.Find("YesButton");   //終了 - はいボタンを格納
        NOButton = GameObject.Find("NoButton");   //終了 - いいえボタンを格納

        STFirstActive = STButton.GetComponent<ButtonFirstActive>();      //スクリプト格納
        YESFirstActive = YESButton.GetComponent<ButtonFirstActive>();     //スクリプト格納

        
        ExitPanel.transform.localPosition = Panel_pos;          //設定された初期位置にExitPanelを移動
        YESButton.GetComponent<ButtonDown>().pos = YESButton.transform.position;
        NOButton.GetComponent<ButtonDown>().pos = NOButton.transform.position;
        ExitPanel.SetActive(false);                             //ExitPanelを非アクティブにする
        
    }

    void Update()
    {
        //ExitPanelが展開されているとき
        if (ExitF)
        {
            ExitPanel.SetActive(true);                             //ExitPanelをアクティブにする
        }
        //ExitPanelが展開されていないとき
        else
        {
            ExitPanel.SetActive(false);                             //ExitPanelを非アクティブにする
        }
    }

    //「ゲーム終了」ボタンを押した時
    public void ExitButtonPush()
    {
        EventSystem.current.SetSelectedGameObject(null);       //ボタンの選択状態を解除
        STButton.GetComponent<ButtonFirstActive>().enabled = false;         //コンポーネントを一時外す
        ExitF = true;
    }

    //「ゲーム終了」 - 「はい」ボタンを押した時
    public void YesButtonPush()
    {
        //ゲームを終了させる
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
              UnityEngine.Application.Quit();
        #endif
    }

    //「ゲーム終了」 - 「いいえ」ボタンを押した時
    public void NoButtonPush()
    {
        STFirstActive.CancelFrag();         //フラグを下げて置く(再びキーボードで選択できるように)
        YESFirstActive.CancelFrag();         //フラグを下げて置く(再びキーボードで選択できるように)
        STButton.GetComponent<ButtonFirstActive>().enabled = true;         //コンポーネントを再びつける
        ExitF = false;
    }
}
