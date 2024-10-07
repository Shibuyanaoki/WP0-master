using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Logic : MonoBehaviour
{
    //プレイヤーの移動する速さ
    public float move_speed = 15;

    //プレイヤーの回転する速さ
    public float rotate_speed = 5;

    //プレイヤーの回転向き
    //1 -> （プレイヤーから見て）時計回り
    //-1 -> （プレイヤーから見て）反時計回り
    private int rotate_direction = 0;

    //プレイヤーのRigidbody
    public Rigidbody Rig = null;

    //地面に着地しているか判定する変数
    public bool grounded;

    //ジャンプ力
    public float jumpPower;

    private float LongPushTime = 0.5f; // 長押しに必要な時間

    public Animator animator;

    private Vector3 Player_Pos;

    private float stick_H;

    private float stick_V;

    // Start is called before the first frame update
    void Start()
    {
        Player_Pos = GetComponent<Transform>().position;
        Rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        stick_H = Input.GetAxis("Horizontal");

        stick_V = Input.GetAxis("Vertical");

        if (Input.GetAxisRaw("Horizontal") < 0 || (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("Vertical") > 0))
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

        if (stick_H != 0 || stick_V != 0)
        {
            var direction = new Vector3(stick_H, 0, stick_V);
            Rig.MovePosition(Rig.position + transform.TransformDirection(direction) * move_speed * Time.deltaTime);
        }

        Horizontal_Rotate();
    }

   

    private void OnCollisionEnter(Collision other)// 他オブジェクトに触れた時の処理
    {
        if (other.gameObject.tag == "Planet")// もしPlanetというタグがついたオブジェクトに触れたら、
        {
            grounded = true;
        }

    }

    void Horizontal_Rotate()
    {
        if (Input.GetAxisRaw("Horizontal R") < 0)
        {
            rotate_direction = -1;
        }
        else if (Input.GetAxisRaw("Horizontal R") > 0)
        {
            rotate_direction = 1;
        }
        else
        {
            rotate_direction = 0;
        }

        // オブジェクトからみて垂直方向を軸として回転させるQuaternionを作成
        Quaternion rot = Quaternion.AngleAxis(rotate_direction * rotate_speed, transform.up);
        // 現在の自信の回転の情報を取得する
        Quaternion q = this.transform.rotation;
        // 合成して、自身に設定
        this.transform.rotation = rot * q;

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    void JumpManager()
    {
        if (grounded == true)
        {
            //if (Input.GetButtonDown("Jump"))
            //{
            //    animator.SetBool("jump", true);
            //    grounded = false;
            //    Rig.AddForce(transform.up * jumpPower * 100);
            //}
            //else
            //{
            //    animator.SetBool("jump", false);
            //}

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Invoke(nameof(LongJump), LongPushTime);
            }
            else if (Input.GetKeyUp(KeyCode.Space) && IsInvoking(nameof(LongJump)))
            {
                CancelInvoke(nameof(LongJump));
                ShortJump();
            }


        }

    }

    void LongJump()
    {
        grounded = false;
        Rig.AddForce(transform.up * jumpPower * 200);
    }

    void ShortJump()
    {
        animator.SetBool("jump", true);
        grounded = false;
        Rig.AddForce(transform.up * jumpPower * 100);
    }

}
