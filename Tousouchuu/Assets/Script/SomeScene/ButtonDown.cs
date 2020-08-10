using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*ボタン押下時の文字下げ*/

public class ButtonDown : MonoBehaviour
{
    GameObject TextGO;     //テキストのゲームオブジェクト
    Text WordText;         //文字のテキスト
    public Vector3 pos;                            //テキストのポジション
    [SerializeField] float Difference;         //文字が動く差分
    bool F;          //文字が沈むフラグ
    bool FF;            

    void Start()
    {
        TextGO = transform.GetChild(0).gameObject;
        WordText = TextGO.GetComponent<Text>();
        pos = TextGO.transform.position;
        F = false;
        FF = false;
    }


    void Update()
    {
        //文字が沈むとき
        if((F || FF) && (!F || FF) && !(!F && FF))
        {
            TextGO.transform.position = new Vector3(pos.x, pos.y - Difference, pos.z);
        }
        //文字が沈まないとき
        else
        {
            TextGO.transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
    }

    //押した時
    public void ButtonPush()
    {
        F = true;
    }

    //離した時
    public void ButtonUp()
    {
        F = false;
    }

    //どけた時
    public void ButtonExit()
    {
        FF = false;
    }

    //ボタンの上に乗っている時
    public void ButtonEnter()
    {
        FF = true;
    }
}
