using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//作成者　桐澤　2020/6/30

public class GoalScore : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //門内部に接触したオブジェクトがタグ"Player"だった場合
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Score_win");//スコアシーンに移動させる
            Debug.Log("ゴール接触");
        }
    }
}
