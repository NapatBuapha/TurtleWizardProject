using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject playerObj;
    [SerializeField] private float startMove_Dis = 10;
    [SerializeField] protected float playerDis;
    protected bool canMove;
    protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObj = GameObject.FindWithTag("Player");
    }

    protected virtual void Update()
    {
        playerDis = Vector2.Distance(transform.position, playerObj.transform.position);
        if (playerDis < startMove_Dis)
        {
            canMove = true;
            Destroy(gameObject, 10);
        }
    }

    protected virtual void FixedUpdate()
    {
        if (!canMove)
            return;

            rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

}
