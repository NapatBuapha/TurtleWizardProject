using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMan : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Rigidbody2D thisRb;

    void Start()
    {
        playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        thisRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        thisRb.velocity = new Vector2(playerRb.velocity.x, 0);
    }
}
