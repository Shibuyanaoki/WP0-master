using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public GameObject playerObject;         //追尾 オブジェクト
    [SerializeField]
    public Vector2 rotationSpeed;           //回転速度
    [SerializeField]
    private Vector3 lastTargetPosition;     //最後の追尾オブジェクトの座標
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
