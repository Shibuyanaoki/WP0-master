using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraController : MonoBehaviour
{

    public GameObject playerObject;         //�ǔ� �I�u�W�F�N�g
    public Vector2 rotationSpeed;           //��]���x
    private Vector3 lastTargetPosition;     //�Ō�̒ǔ��I�u�W�F�N�g�̍��W


    Transform cameraTransform;
   // NavMeshAgent agent = null;


    [SerializeField]
    Vector3 distance;

    private float stick_H;

    private float stick_V;

 
    void Start()
    {

        cameraTransform = Camera.main.transform;

        //agent = GetComponent<NavMeshAgent>();

        StartPosition();
    }

    public void StartPosition()
    {
        transform.position = playerObject.transform.position + distance;
        lastTargetPosition = playerObject.transform.position;
    }

    private void LateUpdate()
    {
        transform.position += playerObject.transform.position - lastTargetPosition;
        lastTargetPosition = playerObject.transform.position;

        //CameraAngre();

    }

    void CameraAngre()
    {
        stick_H = Input.GetAxis("Horizontal");

        stick_V = Input.GetAxis("Vertical");

        var cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;


        //if (stick_H != 0 || stick_V != 0)
        //{
        //    var direction = cameraForward * stick_V + cameraTransform.right * stick_H;
        //    agent.Move(direction * Time.deltaTime);
        //}

        //if (stick_H != 0 || stick_V != 0)
        //{
        //    var direction = cameraForward * stick_V + cameraTransform.right * stick_H;
        //    transform.localRotation = Quaternion.LookRotation(direction);
        //}

    }

}
