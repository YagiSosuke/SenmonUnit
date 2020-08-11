using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*タイトル - 「クレジット」を押した時*/

public class GoCreditButton : MonoBehaviour
{
    //「クレジット」ボタンを押したら
    public void CreditButtonPush()
    {
        feadSC.fade("Credit");       //クレジット画面に遷移
    }
}
