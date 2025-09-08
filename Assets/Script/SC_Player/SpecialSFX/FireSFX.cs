using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSFX : MonoBehaviour
{
    public float fadeDuration = 2f; // เวลาในการจางหาย
    private float fadeTimer;
    private Material material;
    private Color originalColor;

    void Start()
    {
        // ดึง material จาก renderer
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material; // ใช้ instance ของ material
        originalColor = material.color;
        fadeTimer = fadeDuration;
    }

    void Update()
    {
        if (fadeTimer > 0)
        {
            fadeTimer -= Time.deltaTime;
            float alpha = Mathf.Clamp01(fadeTimer / fadeDuration);
            material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
        }
        else
        {
            Destroy(gameObject); // ลบวัตถุหลังจากจางหาย
        }
    }
}
