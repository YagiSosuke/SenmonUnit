using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ネズミのカーソル移動*/

public class NezumiScript : MonoBehaviour
{
    [SerializeField]
    float speed;        //ネズミが進む速度

    [SerializeField]
    GameObject Camera;  //ネズミに追従するカメラ

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.05f;
        Camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Camera.transform.position = new Vector3(this.transform.position.x,
                                                this.transform.position.y+10,
                                                this.transform.position.z);
        //前に進む
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0, 0, speed);
        }
        //後に進む
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0, 0, -speed);
        }
        //右に進む
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(speed, 0, 0);
        }
        //左に進む
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-speed, 0, 0);
        }
    }
}
