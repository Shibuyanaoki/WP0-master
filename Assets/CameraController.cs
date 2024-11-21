using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public GameObject playerObject;         //�ǔ� �I�u�W�F�N�g
    [SerializeField]
    public Vector2 rotationSpeed;           //��]���x
    [SerializeField]
    private Vector3 lastTargetPosition;     //�Ō�̒ǔ��I�u�W�F�N�g�̍��W
    [SerializeField]
    Vector3 distance;

    Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
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

        CameraAngre();

    }

    void CameraAngre()
    {
        var cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;

    }

}
