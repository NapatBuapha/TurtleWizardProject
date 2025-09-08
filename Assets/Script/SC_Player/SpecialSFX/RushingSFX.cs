using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RushingSFX : MonoBehaviour
{
    public GameObject fireSFX;  // วัตถุ Prefab ที่จะสร้าง
    public float spawnInterval = 1f;  // ความถี่ในการ spawn (วินาที)

    private float timer = 0f;
    [SerializeField] private PlayerStateManager player;


    void Update()
    {   if(player.isRushing)
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Instantiate(fireSFX, transform.position, fireSFX.transform.rotation);
            timer = 0f;
        }
    }
}
