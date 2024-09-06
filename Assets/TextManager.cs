using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI text;

    float alfa;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
        text.color = new Color(0.0f, 0.0f, 0.0f, 0.01f);
        alfa = text.color.a;
    }

    public void TitleText()
    {
        text.text = "Game";
    }

    public void GameOverText()
    {
        StartCoroutine("FadeIn");
    }

    public void YButtonText()
    {
        text.text = "Y Button";
    }

    IEnumerator FadeIn()
    {
        text.text = "Game Over";


        alfa += 0.001f;
        text.color = new Color(1, 0, 0, alfa);
        yield return new WaitForSeconds(0.5f);
    }
}
