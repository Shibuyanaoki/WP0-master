using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blinker : MonoBehaviour
{

    public float speed = 1.0f;

    private float time;

    public string nextSceneName;

    [SerializeField]
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.color = GetTextColorAlpha(text.color);

        if(Input.GetAxisRaw("Button Y") != 0)
        {
            SceneManager.LoadScene(nextSceneName);
        }


    }

    Color GetTextColorAlpha(Color color)
    {
        time += Time.deltaTime * speed * 5.0f;
        color.a = Mathf.Sin(time);

        return color;
    }

}
