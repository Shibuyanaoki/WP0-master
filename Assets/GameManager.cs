using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private FadeManager fadeManager;

    [SerializeField]
    private LifeGauge lifeGauge;

    [SerializeField]
    private TextManager textManager;

    [SerializeField]
    string nextSceneName;

    [SerializeField]
    TextMeshProUGUI text;

    private PlayerDamage playerDamage;

    private Rocket rocket;

    // Start is called before the first frame update
    void Start()
    {
        this.playerDamage = FindObjectOfType<PlayerDamage>(); // インスタンス化
        this.rocket = FindObjectOfType<Rocket>(); // インスタンス化
        text.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerDamage.HPProperty == 0)
        {
            lifeGauge.ChangeLife(playerDamage.HPProperty);
            StartCoroutine("GameOver");

            if (Input.GetAxisRaw("Button Y") != 0)
            {
                SceneManager.LoadScene(nextSceneName);
            }

        }
        else if (playerDamage.HPProperty >= 0)
        {
            lifeGauge.ChangeLife(playerDamage.HPProperty);
        }

        if (rocket.GetIsClear == true)
        {

            StartCoroutine("GameClear");


            if (Input.GetAxisRaw("Button Y") != 0)
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }


        ItemNum();

    }

    private void ItemNum()
    {
        text.text = "Item:" + ItemLogger.Count + "/ 5";
    }

    IEnumerator GameClear()
    {
        yield return new WaitForSeconds(1);
        fadeManager.FadeIn();
    }

    IEnumerator GameOver()
    {
        textManager.GameOverText();
        yield return new WaitForSeconds(1);
        fadeManager.FadeOut();
    }

}
