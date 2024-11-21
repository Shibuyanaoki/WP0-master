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
            Debug.Log("当たった");


            if (collision.transform.position.y - 1 >= this.transform.position.y)
            {
                Debug.Log("踏まれた");
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
            Debug.Log("通った");
            FollowPlayer();
        }


        Debug.Log(distanceToPlayer);

        //ApplyGravity();

    }
    void FollowPlayer()
    {
        // プレイヤーの方向を計算
        Vector3 playerDirection = (target.transform.position - transform.position).normalized;

        // 惑星表面に沿った移動方向を計算
        Vector3 gravityDirection = (transform.position - planet.position).normalized;
        Vector3 moveDirection = Vector3.ProjectOnPlane(playerDirection, gravityDirection).normalized;

        // 敵を移動させる
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

}
