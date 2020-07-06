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

    // Start is called before the first frame update
    void Start()
    {
        FirstObject = this.gameObject;          //アタッチしたオブジェクトを格納
    }

    // Update is called once per frame
    void Update()
    {
        //キー操作になっていない && 十字キーかWASDを押すと、キー操作になる
        if(!KeyF && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ||  Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            EventSystem.current.SetSelectedGameObject(FirstObject);         //ボタンをキーボードで操作時、最初に選択状態にする
            FirstObject.GetComponent<Button>().OnSelect(null);              //ハイライト対策

            KeyF = true;
        }

        if(KeyF && Input.GetMouseButtonDown(0))
        {
            KeyF = false;
        }  
    }

    //フラグを消しておく
    public void CancelFrag() {
        KeyF = false;
    }
}
