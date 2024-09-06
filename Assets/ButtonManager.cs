using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    Button startButton;

    [SerializeField]
    Button exitButton;


    // Start is called before the first frame update
    void Start()
    {
        startButton.GetComponent<Button>();
        exitButton.GetComponent<Button>();
        startButton.Select();
    }

    private IEnumerator ForceSelect()
    {
        yield return null; // 1ÉtÉåÅ[ÉÄë“Ç¬
        //EventSystem.current.SetSelectedGameObject(startButton.gameObject);
    }

    public void OnClick()
    {
        Debug.Log("Push");
        //EventSystem.current.SetSelectedGameObject(null);
    }

    public void OnClick2()
    {
        Debug.Log("Push2");
    }

    // Update is called once per frame
    void Update()
    {

    }

}
