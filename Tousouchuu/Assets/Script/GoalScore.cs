using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//作成者　桐澤　2020/6/30
//8/15　八木　ゴール時にわずかにアニメーションを追加

public class GoalScore : MonoBehaviour
{
    float count = 0;              //ゴール後のアニメーションカウント
    bool GoalF = false;         //ゴールしたフラグ
    [SerializeField] GameObject Goaltext;        //ゴール時に出るテキスト
    AudioSource audio;
    [SerializeField] AudioClip clip;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        Goaltext.SetActive(false);
    }

    void Update()
    {
        //ゴールしたら
        if (GoalF)
        {
            Goaltext.SetActive(true);
            if(count == 0)
            {
                audio.PlayOneShot(clip);
            }
            count += Time.deltaTime;
            if (count < .5f)
            {
                Goaltext.transform.eulerAngles = new Vector3(0, 0, -180 + (180 * (1-((1-(count*2))* (1-(count*2))))));
            }
            else if(count < 2f)
            {

            }
            else
            {
                feadSC.fade("Score_win");//スコアシーンに移動させる
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //門内部に接触したオブジェクトがタグ"Player"だった場合
        if (other.gameObject.tag == "Player")
        {
            GoalF = true;   //ゴールフラグを立てる
            Debug.Log("ゴール接触");
        }
    }
}
