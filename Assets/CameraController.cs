using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targetPlayerObject;   // プレイヤーオブジェクト
    public Vector3 offset = new Vector3(0, 2.0f, -5.0f); // プレイヤーからのオフセット
    public float followSpeed = 5f;          // カメラの追従速度
    public float rotationSpeed = 5f;        // カメラの回転速度
    public float distance = 5f;             // プレイヤーとカメラの距離
    public float maxForwardOffset = 0.5f;   // 前方移動時にカメラが進みすぎないための最大オフセット

    private Vector3 velocity = Vector3.zero; // SmoothDamp用の速度
    private GameObject cameraRig;            // 仮想カメラリグ

    void Start()
    {
        // 仮想カメラリグをプレイヤーの子オブジェクトとして生成
        cameraRig = new GameObject("CameraRig");
        cameraRig.transform.SetParent(targetPlayerObject.transform);

        // カメラリグの初期位置をプレイヤーの頭上に設定
        StartPosition();
    }

    internal void StartPosition()
    {
        // カメラリグをプレイヤーの頭上に配置
        cameraRig.transform.position = targetPlayerObject.transform.position + Vector3.up * offset.y;

        // カメラをカメラリグの後方に配置
        Vector3 startPosition = cameraRig.transform.position - cameraRig.transform.forward * distance;
        transform.position = startPosition;

        // カメラがプレイヤーの頭を向くように設定
        transform.LookAt(targetPlayerObject.transform.position + Vector3.up * 1.5f); // プレイヤーの頭に向く
    }

    private void LateUpdate()
    {
        // カメラリグの位置をプレイヤーに追従させる
        cameraRig.transform.position = targetPlayerObject.transform.position + Vector3.up * offset.y;

        // カメラの追従と回転を処理
        SmoothFollow();
        MaintainCameraRotation();
    }

    void SmoothFollow()
    {
        // プレイヤーの前後移動時にカメラが進みすぎないようにオフセットを制限
        Vector3 playerDirection = targetPlayerObject.transform.TransformDirection(offset);

        // カメラのターゲット位置を計算（前方移動時のオフセットを制限）
        Vector3 targetPosition = targetPlayerObject.transform.position + Vector3.ClampMagnitude(playerDirection, distance - maxForwardOffset);

        // カメラの位置を滑らかにプレイヤーに追従（SmoothDampを使用）
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, followSpeed * Time.deltaTime);
    }

    void MaintainCameraRotation()
    {
        // プレイヤーのローカルな「上方向」を基準にカメラの回転を設定
        Vector3 directionToPlayer = targetPlayerObject.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, targetPlayerObject.transform.up);

        // プレイヤーを追いながら、回転をプレイヤーの上方向に合わせる
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
