using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{

    float Speed = 0.001f;
    float red, green, blue, alfa;
    float alfa2;

    //public bool Out = false;
    //public bool In = false;

    [SerializeField]
    Image fadeOut;

    [SerializeField]
    Image fadeIn;

    // Start is called before the first frame update
    void Start()
    {
        fadeOut.GetComponent<Image>();
        red = fadeOut.color.r;
        green = fadeOut.color.g;
        blue = fadeOut.color.b;
        alfa = fadeOut.color.a;

        fadeIn.GetComponent<Image>();

        alfa2 = fadeIn.color.a;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeIn()
    {
        fadeIn.enabled = true;
        alfa2 += Speed;
        fadeIn.color = new Color(255, 255, 255, alfa2);
        
    }

    public void FadeOut()
    {
        fadeOut.enabled = true;
        alfa += Speed;
        fadeOut.color = new Color(0, 0, 0, alfa);
        //Alpha();
    }

    void Alpha()
    {
        fadeOut.color = new Color(red, green, blue, alfa);
    }

}
