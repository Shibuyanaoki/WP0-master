using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Logic : MonoBehaviour
{

    public Transform target;
    public Transform planet;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float rotationSpeed = 10.0f;

    [SerializeField]
    private float followRange = 20.0f;

    [SerializeField]
    private float stopRange = 5f;

    // Start is called before the first frame update
    public void Start()
    {
        //target = GameObject.Find("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == ("Player"))
        {
            Debug.Log("��������");


            if (collision.transform.position.y - 1 >= this.transform.position.y)
            {
                Debug.Log("���܂ꂽ");
                Destroy(this.gameObject);
            }
        }
    }

    

    // Update is called once per frame
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);

        if (distanceToPlayer <= followRange /*&& distanceToPlayer > stopRange*/)
        {
            Debug.Log("�ʂ���");
            FollowPlayer();
        }


        Debug.Log(distanceToPlayer);

        //ApplyGravity();

    }
    void FollowPlayer()
    {
        // �v���C���[�̕������v�Z
        Vector3 playerDirection = (target.transform.position - transform.position).normalized;

        // �f���\�ʂɉ������ړ��������v�Z
        Vector3 gravityDirection = (transform.position - planet.position).normalized;
        Vector3 moveDirection = Vector3.ProjectOnPlane(playerDirection, gravityDirection).normalized;

        // �G���ړ�������
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

}
