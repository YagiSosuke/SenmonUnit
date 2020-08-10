using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*ボタンをキーボードで操作時、最初に選択状態にするスクリプト*/

public class ButtonFirstActive : MonoBehaviour
{
    GameObject FirstObject;     //最初にキー押下時に選択するオブジェクト
    public bool KeyF = false;          //キーボード操作になっているか

    [SerializeField] GameObject Cursor;      //カーソル
    [SerializeField] List<Vector3> pos;      //座標系いろいろ
    [SerializeField] int Length;     //配列サイズ
    public int nowPos;     //カーソルがいる位置
    [SerializeField] bool UtoD;         //縦のボタンの時

    // Start is called before the first frame update
    void Start()
    {
        FirstObject = this.gameObject;          //アタッチしたオブジェクトを格納
        Cursor.gameObject.SetActive(false);                //消す
        nowPos = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //キー操作になっていない && 十字キーかWASDを押すと、キー操作になる
        if(!KeyF && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ||  Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            EventSystem.current.SetSelectedGameObject(FirstObject);         //ボタンをキーボードで操作時、最初に選択状態にする
            FirstObject.GetComponent<Button>().OnSelect(null);              //ハイライト対策
            Cursor.gameObject.SetActive(true);         //出す
            Cursor.transform.localPosition = pos[0];        //位置合わせ
            nowPos = -1;

            KeyF = true;
        }
        if(KeyF && Input.GetMouseButtonDown(0))
        {
            Cursor.gameObject.SetActive(false);                //消す
            KeyF = false;
        }



        //カーソルを移動させるスクリプト
        //縦移動の時
        if (UtoD)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && Length > nowPos + 1)
            {
                nowPos++;
                Cursor.transform.localPosition = pos[nowPos];
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && 0 <= nowPos - 1)
            {
                nowPos--;
                Cursor.transform.localPosition = pos[nowPos];
            }
        }
        //横移動の時
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && Length > nowPos + 1)
            {
                nowPos++;
                Cursor.transform.localPosition = pos[nowPos];
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && 0 <= nowPos - 1)
            {
                nowPos--;
                Cursor.transform.localPosition = pos[nowPos];
            }
        }

    }

    //フラグを消しておく
    public void CancelFrag() {
        KeyF = false;
    }
}
