using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{
    Animator animator;

    GameObject playerObj;
    [SerializeField] private float startMove_Dis = 10;
    [SerializeField] protected float playerDis;
    [SerializeField] protected float speed;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerObj = GameObject.FindWithTag("Player");
    }

    protected virtual void Update()
    {
        playerDis = Vector2.Distance(transform.position, playerObj.transform.position);
        if (playerDis < startMove_Dis)
        {
            animator.SetTrigger("Pull");
            Destroy(gameObject, 2);
        }

        
    }
}
