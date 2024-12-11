using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public Renderer targetRenderer; // �_�ł�����I�u�W�F�N�g��Renderer
    public Color flashColor = Color.red; // �_���[�W���̓_�ŐF
    public int flashCount = 3; // �_�ŉ�
    public float flashDuration = 0.1f; // �_�ŊԊu

    private Color originalColor; // ���̐F
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
        StopAllCoroutines(); // ���̓_�ł��i�s���̏ꍇ�A��~
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
