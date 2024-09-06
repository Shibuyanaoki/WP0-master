using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGauge : MonoBehaviour
{

    //[SerializeField]
    public Image image;

    private Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        image.GetComponent<Image>();
    }

    public void ChangeLife(int HP)
    {
        if(HP == 3)
        {
            sprite = Resources.Load<Sprite>("GreenGauge");
            //image.GetComponent<Image>(); 
            image.sprite = sprite;
        }

        if(HP == 2)
        {
            sprite = Resources.Load<Sprite>("YellowGauge");
            //image.GetComponent<Image>();
            image.sprite = sprite;
        }

        if (HP == 1)
        {
            sprite = Resources.Load<Sprite>("RedGauge");
            //image = this.GetComponent<Image>();
            image.sprite = sprite;
        }

        if(HP == 0)
        {
            sprite = Resources.Load<Sprite>("GaugeEnd");
            //image = this.GetComponent<Image>();
            image.sprite = sprite;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
