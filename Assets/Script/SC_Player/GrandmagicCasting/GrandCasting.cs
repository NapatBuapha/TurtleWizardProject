using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrandCasting : MonoBehaviour
{
    
    public GameObject prefab;
    public float obstacleBias = 0.7f; // โอกาสที่ spawn ใกล้ obstacle (0.7 = 70%)
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

        if (Random.value < obstacleBias)
        {
            // --- Spawn ใกล้ obstacle ---
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Enemy");
            if (obstacles.Length > 0)
            {
                GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];
                spawnPos = (Vector2)obstacle.transform.position +
                           Random.insideUnitCircle * spawnRadius;
            }
            else
            {
                spawnPos = GetRandomScreenPosition();
            }
        }
        else
        {
            // --- Spawn ทั่วจอ ---
            spawnPos = GetRandomScreenPosition();
        }

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
