using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rocket : MonoBehaviour
{

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject rocket;

    [SerializeField]
    GameObject text;

    CameraController cameraController;

    private bool isPhase = false;

    private bool isClear = false;

    public bool GetIsClear
    {
        get => isClear;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.cameraController = FindObjectOfType<CameraController>(); // インスタンス化
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.SetActive(true);

            if (Input.GetAxisRaw("Button Y") != 0)
            {
                Debug.Log("押した");

                if (isPhase == true)
                {
                    Debug.Log("clear");
                    isClear = true;
                }

                if (ItemLogger.Count == 5 && isPhase == false)
                {
                    ItemLogger.Clear();

                    Debug.Log(ItemLogger.Count);

                    player.transform.position = new Vector3(-20.5f, 25.6f, -38);

                    rocket.transform.position = new Vector3(-82, 20, -40);
                    rocket.transform.Rotate(-90, 180, 90);

                    isPhase = true;

                    //cameraController.StartPosition();
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
