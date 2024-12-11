using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public Renderer targetRenderer; // 点滅させるオブジェクトのRenderer
    public Color flashColor = Color.red; // ダメージ時の点滅色
    public int flashCount = 3; // 点滅回数
    public float flashDuration = 0.1f; // 点滅間隔

    private Color originalColor; // 元の色
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        if (targetRenderer == null)
        {
            targetRenderer = GetComponent<Renderer>();
        }
        material = targetRenderer.material;
        originalColor = material.color;
    }

    public void TriggerFlash()
    {
        StopAllCoroutines(); // 他の点滅が進行中の場合、停止
        StartCoroutine(FlashRoutine());
    }

    private System.Collections.IEnumerator FlashRoutine()
    {
        for (int i = 0; i < flashCount; i++)
        {
            material.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            material.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
