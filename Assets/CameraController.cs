using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targetPlayerObject;   // �v���C���[�I�u�W�F�N�g
    public Vector3 offset = new Vector3(0, 2.0f, -5.0f); // �v���C���[����̃I�t�Z�b�g
    public float followSpeed = 5f;          // �J�����̒Ǐ]���x
    public float rotationSpeed = 5f;        // �J�����̉�]���x
    public float distance = 5f;             // �v���C���[�ƃJ�����̋���
    public float maxForwardOffset = 0.5f;   // �O���ړ����ɃJ�������i�݂����Ȃ����߂̍ő�I�t�Z�b�g

    private Vector3 velocity = Vector3.zero; // SmoothDamp�p�̑��x
    private GameObject cameraRig;            // ���z�J�������O

    void Start()
    {
        // ���z�J�������O���v���C���[�̎q�I�u�W�F�N�g�Ƃ��Đ���
        cameraRig = new GameObject("CameraRig");
        cameraRig.transform.SetParent(targetPlayerObject.transform);

        // �J�������O�̏����ʒu���v���C���[�̓���ɐݒ�
        StartPosition();
    }

    internal void StartPosition()
    {
        // �J�������O���v���C���[�̓���ɔz�u
        cameraRig.transform.position = targetPlayerObject.transform.position + Vector3.up * offset.y;

        // �J�������J�������O�̌���ɔz�u
        Vector3 startPosition = cameraRig.transform.position - cameraRig.transform.forward * distance;
        transform.position = startPosition;

        // �J�������v���C���[�̓��������悤�ɐݒ�
        transform.LookAt(targetPlayerObject.transform.position + Vector3.up * 1.5f); // �v���C���[�̓��Ɍ���
    }

    private void LateUpdate()
    {
        // �J�������O�̈ʒu���v���C���[�ɒǏ]������
        cameraRig.transform.position = targetPlayerObject.transform.position + Vector3.up * offset.y;

        // �J�����̒Ǐ]�Ɖ�]������
        SmoothFollow();
        MaintainCameraRotation();
    }

    void SmoothFollow()
    {
        // �v���C���[�̑O��ړ����ɃJ�������i�݂����Ȃ��悤�ɃI�t�Z�b�g�𐧌�
        Vector3 playerDirection = targetPlayerObject.transform.TransformDirection(offset);

        // �J�����̃^�[�Q�b�g�ʒu���v�Z�i�O���ړ����̃I�t�Z�b�g�𐧌��j
        Vector3 targetPosition = targetPlayerObject.transform.position + Vector3.ClampMagnitude(playerDirection, distance - maxForwardOffset);

        // �J�����̈ʒu�����炩�Ƀv���C���[�ɒǏ]�iSmoothDamp���g�p�j
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, followSpeed * Time.deltaTime);
    }

    void MaintainCameraRotation()
    {
        // �v���C���[�̃��[�J���ȁu������v����ɃJ�����̉�]��ݒ�
        Vector3 directionToPlayer = targetPlayerObject.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, targetPlayerObject.transform.up);

        // �v���C���[��ǂ��Ȃ���A��]���v���C���[�̏�����ɍ��킹��
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
