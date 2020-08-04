using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*HPバーのスクリプト*/

public class HPScript : MonoBehaviour
{
    public float HP = 1f;
    [SerializeField] float Damage;
    GameObject MainCamera;      //メインカメラのオブジェクト
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.LookAt(MainCamera.transform);
    }
}
