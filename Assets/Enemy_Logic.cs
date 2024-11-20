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
            Debug.Log("“–‚½‚Á‚½");


            if (collision.transform.position.y - 1 >= this.transform.position.y)
            {
                Debug.Log("“¥‚Ü‚ê‚½");
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
            Debug.Log("’Ê‚Á‚½");
            FollowPlayer();
        }


        Debug.Log(distanceToPlayer);

        //ApplyGravity();

    }
    void FollowPlayer()
    {
        // ƒvƒŒƒCƒ„[‚Ì•ûŒü‚ğŒvZ
        Vector3 playerDirection = (target.transform.position - transform.position).normalized;

        // ˜f¯•\–Ê‚É‰ˆ‚Á‚½ˆÚ“®•ûŒü‚ğŒvZ
        Vector3 gravityDirection = (transform.position - planet.position).normalized;
        Vector3 moveDirection = Vector3.ProjectOnPlane(playerDirection, gravityDirection).normalized;

        // “G‚ğˆÚ“®‚³‚¹‚é
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    //void ApplyGravity()
    //{
    //    // ˜f¯‚Ì’†S•ûŒü‚ğŒvZ
    //    Vector3 gravityDirection = (transform.position - planet.position).normalized;

    //    // “G‚Ì‰º•ûŒü‚ğ˜f¯‚Ì’†S‚ÉŒü‚¯‚é
    //    Quaternion targetRotation = Quaternion.FromToRotation(transform.up, gravityDirection) * transform.rotation;
    //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    //}

}
