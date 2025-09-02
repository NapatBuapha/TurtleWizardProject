using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrandCasting : MonoBehaviour
{
    
    public GameObject prefab;
    public float spawnRadius = 1f;
    public Vector2 screenMin, screenMax; // ขอบจอ (เช่น (-8,-4), (8,4))
    Camera cam;
    [SerializeField] private float spawnCooldown = 0.1f;
    private float cooldown;

    public bool isGrandCasting;

    void Start()
    {
        cam = Camera.main;
        isGrandCasting = false;
    }

    public void GetBounds()
    {
        screenMin = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        screenMax = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
    }

    void FixedUpdate()
    {
        
        if (isGrandCasting)
        {
            if (cooldown < spawnCooldown)
            {
                cooldown += Time.deltaTime;
            }
            else
            {
                cooldown = 0;
                GetBounds();
                Spawn();
            }
            
        }
    }

    void Spawn()
    {
        Vector2 spawnPos;
        spawnPos = GetRandomScreenPosition();
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }

    Vector2 GetRandomScreenPosition()
    {
        return new Vector2(
            Random.Range(screenMin.x, screenMax.x),
            Random.Range(screenMin.y, screenMax.y)
        );
    }
    
}
