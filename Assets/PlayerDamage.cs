using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerDamage : MonoBehaviour
{

    /// <summary> モデルのRenderer </summary>
    [SerializeField]
    private Renderer renderer;

    [SerializeField]
    private bool invincible = false;

    [SerializeField]
    private float invincibleTime = 0.5f;

    [SerializeField]
    private int HP = 3;

    public int HPProperty
    {
        get { return HP; }
        set { HP = value; }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            if (invincible == false)
            {
                HP--;
                Debug.Log("Damage");
                DamageEffect();
            }

        }
    }

    /// <summary> カラー乗算によるダメージ演出再生と無敵時間 </summary>
    private void DamageEffect()
    {
        if ((HP != 0))
        {
           
        }
    }

}
