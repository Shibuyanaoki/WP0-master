using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerDamage : MonoBehaviour
{

    /// <summary> モデルのRenderer </summary>
    [SerializeField]
    private Renderer _renderer;

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
        if (collision.gameObject.tag == "Stone")
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
            var sequence = DOTween.Sequence();

            sequence.Append(this._renderer.material.DOColor(Color.red, invincibleTime));
            sequence.Append(this._renderer.material.DOColor(Color.white, invincibleTime));

            sequence.Play().OnStart(() => { invincible = true; }).SetLoops(3).OnComplete(() => { invincible = false; });
        }
    }

}
