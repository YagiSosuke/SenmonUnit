using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*クレジット画面 - タイトルに戻るボタン処理*/

public class GoTitleButton : MonoBehaviour
{
    //「タイトル」ボタンを押したら
    public void TitleButtonPush()
    {
        feadSC.fade("Title");        //タイトル画面に遷移
    }
}
