using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField]
    Rigidbody rig;

    [SerializeField]
    float speed;

    [SerializeField]
    Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        rig.MovePosition(rig.position + transform.TransformDirection(new Vector3(0,0,1)) * speed * Time.deltaTime);

        //transform.localRotation *= Quaternion.FromToRotation()

    }
}
