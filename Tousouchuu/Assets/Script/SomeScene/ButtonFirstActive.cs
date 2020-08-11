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
    [SerializeField] Vector3 pos;      //現在のボタンの座標からどれほどの位置にいるか
    [SerializeField] bool UtoD;         //縦のボタンの時
    GameObject ActiveButton;            //選択状態にあるボタンを格納する
    [SerializeField] EventSystem eventSystem;       //イベントシステムを取得用

    // Start is called before the first frame update
    void Start()
    {
        FirstObject = this.gameObject;          //アタッチしたオブジェクトを格納
        Cursor.gameObject.SetActive(false);                //消す
    }

    // Update is called once per frame
    void Update()
    {     


        //キー操作になっていない && 十字キーかWASDを押すと、キー操作になる
        if (!KeyF && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ||  Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            EventSystem.current.SetSelectedGameObject(FirstObject);         //ボタンをキーボードで操作時、最初に選択状態にする
            FirstObject.GetComponent<Button>().OnSelect(null);              //ハイライト対策
            Cursor.gameObject.SetActive(true);         //出す

            //現在選択中のボタンを受け取る
            ActiveButton = eventSystem.currentSelectedGameObject.gameObject;
            //カーソル表示
            Cursor.transform.localPosition = new Vector3(ActiveButton.transform.localPosition.x + pos.x, ActiveButton.transform.localPosition.y + pos.y, ActiveButton.transform.localPosition.z + pos.z);
            

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
            if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)))
            {
                //現在選択中のボタンを変数に格納
                ActiveButton = eventSystem.currentSelectedGameObject.gameObject;
                Debug.Log(ActiveButton);

                //カーソル表示
                Cursor.transform.localPosition = new Vector3(ActiveButton.transform.localPosition.x + pos.x, ActiveButton.transform.localPosition.y + pos.y, ActiveButton.transform.localPosition.z + pos.z);
                
            }
            else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
            {
                //現在選択中のボタンを変数に格納
                ActiveButton = eventSystem.currentSelectedGameObject.gameObject;
                Debug.Log(ActiveButton);

                //カーソル表示
                Cursor.transform.localPosition = new Vector3(ActiveButton.transform.localPosition.x + pos.x, ActiveButton.transform.localPosition.y + pos.y, ActiveButton.transform.localPosition.z + pos.z);
            }
        }
        //横移動の時
        else
        {
            if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)))
            {

                //現在選択中のボタンを変数に格納
                ActiveButton = eventSystem.currentSelectedGameObject.gameObject;
                Debug.Log(ActiveButton);

                //カーソル表示
                Cursor.transform.localPosition = new Vector3(ActiveButton.transform.localPosition.x + pos.x, ActiveButton.transform.localPosition.y + pos.y, ActiveButton.transform.localPosition.z + pos.z);
            }
            else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)))
            {
                //現在選択中のボタンを変数に格納
                ActiveButton = eventSystem.currentSelectedGameObject.gameObject;
                Debug.Log(ActiveButton);

                //カーソル表示
                Cursor.transform.localPosition = new Vector3(ActiveButton.transform.localPosition.x + pos.x, ActiveButton.transform.localPosition.y + pos.y, ActiveButton.transform.localPosition.z + pos.z);
            }
        }

    }

    //フラグを消しておく
    public void CancelFrag() {
        KeyF = false;
    }
}
