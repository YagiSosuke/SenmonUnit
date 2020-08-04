using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*HPバーのスクリプト*/

public class HPScript : MonoBehaviour
{
    public static float HP = 1f;            //ネズミのHP
    public static float Damage = 0.35f;          //ネコに当たった時、どれくらいダメージを受けるか
    GameObject MainCamera;      //メインカメラのオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
    }    

    //ダメージを受ける
    public static void ReceiveDamage() {
        if(HP - Damage > 0)     //ダメージを受けても体力が残るなら
        {
            HP -= Damage;       //ダメージを受ける
        }
        //体力が0以下になってしまうなら
        else
        {
            HP = 0;
        }
    } 

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.LookAt(MainCamera.transform);
    }
}
