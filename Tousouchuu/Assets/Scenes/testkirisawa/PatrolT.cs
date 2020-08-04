using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NavMeshAgent使うときに必要
using UnityEngine.AI;

//桐澤　2020/7/7 テスト用のAI巡回プログラム
//桐澤　2020/7/21 ネズミを追いかけるように
//桐澤　2020/8/4 猫っぽい動作になるように変更

//猫について
//猫は獲物をもてあそんで食べるため即死するわけではない
//猫の視野は薬200度
//視力はそれほど良くなく、良く見えるのは6m程度
//

    //忍び寄る
    //一気に近づく
    //捕まえたら食べる

/// <summary>
/// 優先①　猫っぽい動き
/// 優先②　視野角制限
/// 優先③　
/// 優先④　
/// </summary>

//オブジェクトにNavMeshAgentコンポーネントを設置
[RequireComponent(typeof(NavMeshAgent))]

public class PatrolT : MonoBehaviour
{

    public Transform[] points;
    [SerializeField] int destPoint = 0;//次の目標地点管理用　1 2 3 1 2 3 1 2 3 と偏移
    private NavMeshAgent agent;

    Vector3 playerPos;
    GameObject player;
    float distance;


    [SerializeField] float SONRange = 15f;//初期反応距離//ステルス追跡を始める距離
    [SerializeField] float GOCATRange = 8f;//攻撃開始距離//入ったら叫びジャンプを行いダッシュを始める
    [SerializeField] float DSRange = 5f;//追跡を中断する距離 ダッシュ状態から逃げるのに必要な距離//このままだとダッシュ入った瞬間に入るのでboolと組み合わせること

    private bool Attak;

    [SerializeField] float SS = 2f;//追跡速度　高いほど遅い
    [SerializeField] float AS = 20f;//攻撃速度　高いほど早い

    [SerializeField] bool tracking = false;//追跡中かどうかのbool

    ///original↓
    private bool PlayerDiscovery;
    public AudioClip sound1;
    AudioSource audioSource;

    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // autoBraking を無効にすると、目標地点の間を継続的に移動します
        //(つまり、エージェントは目標地点に近づいても
        // 速度をおとしません)
        agent.autoBraking = false;

        GotoNextPoint();

        //追跡したいオブジェクトの名前を入れる
        player = GameObject.Find("NezumiPrefab");
        PlayerDiscovery = false;
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();//デフォルトでwalk
        //animator.SetBool("", bool); アニメ使い方　SON GOCAT PreON すべてbool

        Attak = false;
    }


    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返します
        if (points.Length == 0)
            return;

        // エージェントが現在設定された目標地点に行くように設定します
        agent.destination = points[destPoint].position;

        // 配列内の次の位置を目標地点に設定し、
        // 必要ならば出発地点にもどります
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        //Playerとこのオブジェクトの距離を測る
        playerPos = player.transform.position;
        distance = Vector3.Distance(this.transform.position, playerPos);

        //Debug.Log(distance);//プレイヤーとcatの距離


        if (tracking == true)//追跡中
        {
            agent.destination = playerPos;

            if (distance > SONRange)//追跡距離よりも距離を取られた
            {
                tracking = false;//追跡を中断
                animator.SetBool("SON", false); //移動モードに移行
                agent.speed *= SS;
                Debug.Log("追跡中断");
            }


            if(distance < GOCATRange)//攻撃距離圏内に入ったら
            {
                if (Attak == false)
                {
                    audioSource.PlayOneShot(sound1);//開始時に1度だけ鳴く
                    Attak = true;//攻撃を開始
                    animator.SetBool("GOCAT", true); //攻撃モードに移行
                    agent.speed *= AS;
                    Debug.Log("攻撃開始");
                }
            }

            if (Attak == true)
            {
                if (distance > GOCATRange)//攻撃距離よりも距離を取られたら
                {
                    Attak = false;//攻撃を中断
                    animator.SetBool("GOCAT", false); //追跡モードに移行
                    agent.speed /= AS;
                    Debug.Log("攻撃中断");
                }
            }
        }
        else//追跡中でない
        {
            agent.destination = points[destPoint].position;

            if (distance < SONRange)//PlayerがtrackingRangeより近づいたら追跡開始
            {
                tracking = true;//追跡を開始する
                animator.SetBool("SON", true); //追跡モードに移行
                agent.speed /= SS;
                Debug.Log("追跡開始");
                //Playerを目標とする
                agent.destination = playerPos;
            }


            // エージェントが現目標地点に近づいてきたら、
            // 次の目標地点を選択します
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        //SONRangeの範囲を青いワイヤーフレームで示す　//ステルス開始距離
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, SONRange);

        //quitRangeの範囲を赤いワイヤーフレームで示す　//攻撃開始距離
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, GOCATRange);
    }

    public bool GetTrak()
    {
        return tracking;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)//プレイヤーとあったた（捕獲）した場合
        {
            animator.SetBool("PreON", true); //捕食モードに移行
            agent.destination = this.transform.position;//現在の自分の座標を目標地点として、動かなくする（その辺をうろつかせる？
        }
    }
}