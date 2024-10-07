using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Logic : MonoBehaviour
{
    //�v���C���[�̈ړ����鑬��
    public float move_speed = 15;

    //�v���C���[�̉�]���鑬��
    public float rotate_speed = 5;

    //�v���C���[�̉�]����
    //1 -> �i�v���C���[���猩�āj���v���
    //-1 -> �i�v���C���[���猩�āj�����v���
    private int rotate_direction = 0;

    //�v���C���[��Rigidbody
    public Rigidbody Rig = null;

    //�n�ʂɒ��n���Ă��邩���肷��ϐ�
    public bool grounded;

    //�W�����v��
    public float jumpPower;

    private float LongPushTime = 0.5f; // �������ɕK�v�Ȏ���

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

   

    private void OnCollisionEnter(Collision other)// ���I�u�W�F�N�g�ɐG�ꂽ���̏���
    {
        if (other.gameObject.tag == "Planet")// ����Planet�Ƃ����^�O�������I�u�W�F�N�g�ɐG�ꂽ��A
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

        // �I�u�W�F�N�g����݂Đ������������Ƃ��ĉ�]������Quaternion���쐬
        Quaternion rot = Quaternion.AngleAxis(rotate_direction * rotate_speed, transform.up);
        // ���݂̎��M�̉�]�̏����擾����
        Quaternion q = this.transform.rotation;
        // �������āA���g�ɐݒ�
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
