using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingArrow : Arrow
{
    [SerializeField] private bool isFalling;
    [SerializeField] private float fallingDistance;
    [SerializeField] private float speedDropRate;
    [SerializeField] private float rotationSpeed = 10f; 
    protected override void Update()
    {
        base.Update();

        if (playerDis < fallingDistance)
        {
            isFalling = true;
        }

    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (isFalling)
        {
            rb.gravityScale = 1;
            if (speed > 0)
            {
                speed -= speedDropRate;
            }

            if (transform.eulerAngles.z < 160 && rb.velocity.x < 10)
            {
                transform.Rotate(Vector3.forward * rotationSpeed);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            rb.bodyType = RigidbodyType2D.Static;
            Destroy(this);
        }


    }
}
