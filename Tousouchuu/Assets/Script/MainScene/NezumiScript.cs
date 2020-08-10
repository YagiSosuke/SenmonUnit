
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ネズミのキーボード移動*/

public class NezumiScript : MonoBehaviour
{
    [SerializeField] GameObject MouseObject;    //ネズミのゲームオブジェクトを格納
    [SerializeField] float speed;        //ネズミが進む速度
    [SerializeField] GameObject Camera;  //ネズミに追従するカメラ

    string LookDirection;   //向く方向
    Vector3 BeforeLookVector;        //現在向いている方向
    Vector3 AfterLookVector;         //向きたい方向
    float SpinCount;                 //方向を向くまでのカウント

    bool MouseUpF;          //ネズミが前に進んでいるフラグ
    bool MouseDownF;        //ネズミが後ろに進んでいるフラグ
    bool MouseRightF;       //ネズミが右に進んでいるフラグ
    bool MouseLeftF;        //ネズミが左に進んでいるフラグ

    [SerializeField] GameObject PauseObject;        //「ポーズスクリプト」が入っているオブジェクト     
    PauseScript pausescript;            //「ポーズスクリプト」を格納

    Animator animator;                  //ネズミのアニメーター

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("CameraGroop");        //カメラを格納

        LookDirection = "Up";         //進む方向は最初は前
        BeforeLookVector = new Vector3(0, 0, 0);        //現在向いている方向
        AfterLookVector = new Vector3(0, 0, 0);         //向きたい方向
        SpinCount = 0;

        MouseUpF = false;          //前に進んでいるフラグはfalse
        MouseDownF = false;        //後ろに進んでいるフラグはfalse
        MouseRightF = false;       //右に進んでいるフラグはfalse
        MouseLeftF = false;        //左に進んでいるフラグはfalse

        PauseObject = GameObject.Find("Canvas");        //オブジェクトを格納
        pausescript = PauseObject.GetComponent<PauseScript>();      //スクリプトを格納

        animator = MouseObject.GetComponent<Animator>();            //鼠のアニメーター
    }

    // Update is called once per frame
    void Update()
    {
        //ポーズ画面でない場合
        if (!pausescript.PauseF)
        {
            //前に進む
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                MouseUpF = true;        //前に進むフラグはtrueに
                MouseSpin(LookDirection);
            }
            else
            {
                MouseUpF = false;        //前に進むフラグはfalseに
            }
            //後に進む
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                MouseDownF = true;        //後ろに進むフラグはtrueに
                MouseSpin(LookDirection);
            }
            else
            {
                MouseDownF = false;        //後ろに進むフラグはfalseに
            }
            //右に進む
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                MouseRightF = true;        //右に進むフラグはtrueに
                MouseSpin(LookDirection);
            }
            else
            {
                MouseRightF = false;        //右に進むフラグはfalseに
            }
            //左に進む
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                MouseLeftF = true;        //左に進むフラグはtrueに
                MouseSpin(LookDirection);
            }
            else
            {
                MouseLeftF = false;        //左に進むフラグはfalseに
            }



            //移動キーが押されていない場合
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow))
            {
                animator.SetBool("RunF", false);     //走るアニメーションを停止
            }
            //移動キーを押した瞬間
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                BeforeLookVector = transform.rotation.eulerAngles;          //回転前の向いている方向
                SpinCount = 0;
            }
            //移動キーを離した瞬間
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                BeforeLookVector = transform.rotation.eulerAngles;          //回転前の向いている方向
                SpinCount = 0;
            }
            //移動キーを押している間
            else
            {
                WalkingDirection();         //進む方向を決定
                animator.SetBool("RunF", true);     //走るアニメーションを再生
                this.transform.Translate(0, 0, speed * Time.deltaTime);             //向いている方向に進む
            }
        }


        //追従カメラの設置
        Camera.transform.position = new Vector3(this.transform.position.x,
                                                this.transform.position.y + 10,
                                                this.transform.position.z);
    }

    //押されたキーの要素によって進む方向を決定
    void WalkingDirection()
    {
        //右上に進んでいる場合
        if (MouseUpF && MouseRightF)
        {
            LookDirection = "UpRight";
            if (MouseDownF) LookDirection = "Right";        //下も押されていたら右に進む
            else if (MouseLeftF) LookDirection = "Up";      //左も押されていたら上に進む
        }
        //左上に進んでいる場合
        else if (MouseUpF && MouseLeftF)
        {
            LookDirection = "UpLeft";
            if (MouseDownF) LookDirection = "Left";        //下も押されていたら左に進む
            else if (MouseRightF) LookDirection = "Up";      //右も押されていたら上に進む
        }
        //右下に進んでいる場合
        else if (MouseDownF && MouseRightF)
        {
            LookDirection = "DownRight";
            if (MouseUpF) LookDirection = "Right";        //上も押されていたら右に進む
            else if (MouseLeftF) LookDirection = "Down";      //左も押されていたら下に進む
        }
        //左下に進んでいる場合
        else if (MouseDownF && MouseLeftF)
        {
            LookDirection = "DownLeft";
            if (MouseUpF) LookDirection = "Left";        //上も押されていたら左に進む
            else if (MouseRightF) LookDirection = "Down";      //右も押されていたら下に進む
        }
        //上に進んでいる場合
        else if (MouseUpF)
        {
            LookDirection = "Up";
        }
        //下に進んでいる場合
        else if (MouseDownF)
        {
            LookDirection = "Down";
        }
        //右に進んでいる場合
        else if (MouseRightF)
        {
            LookDirection = "Right";
        }
        //左に進んでいる場合
        else if (MouseLeftF)
        {
            LookDirection = "Left";
        }
    }


    //ネズミが回転する - 進む向きを引数にする
    void MouseSpin(string Look)
    {
        //引数によって向く方向を変える
        switch (Look)
        {
            case "Up":
                AfterLookVector = new Vector3(0, 0, 0);
                break;

            case "UpRight":
                AfterLookVector = new Vector3(0, 45, 0);
                break;

            case "Right":
                AfterLookVector = new Vector3(0, 90, 0);
                break;

            case "DownRight":
                AfterLookVector = new Vector3(0, 135, 0);
                break;

            case "Down":
                AfterLookVector = new Vector3(0, 180, 0);
                break;

            case "DownLeft":
                AfterLookVector = new Vector3(0, 225, 0);
                break;

            case "Left":
                AfterLookVector = new Vector3(0, 270, 0);
                break;

            case "UpLeft":
                AfterLookVector = new Vector3(0, 315, 0);
                break;
        }

        if (SpinCount < 1)
        {
            SpinCount += 0.1f;
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(BeforeLookVector), Quaternion.Euler(AfterLookVector), SpinCount);
        }
    }
}
