using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*タイトル - ゲーム終了動作*/

public class ExitButton : MonoBehaviour
{
    [SerializeField] GameObject ExitPanel;      //ゲーム終了の確認パネル
    Vector3 Panel_pos;          //ExitPanelは最初は邪魔にならないよう移動させてある、位置をセットしてあげる
    public bool ExitF;          //ExitPanelが展開されているかを見るフラグ(展開されている:true 展開されていない:false)

    void Start()
    {
        ExitPanel = GameObject.Find("ExitCheckPanel");          //ExitPanel変数に格納
        Panel_pos = new Vector3(0, 0, 0);                       //初期位置を設定
        ExitF = false;                                          //ExitPanelが展開されていない

        ExitPanel.transform.localPosition = Panel_pos;          //設定された初期位置にExitPanelを移動
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
        ExitF = false;
    }
}
