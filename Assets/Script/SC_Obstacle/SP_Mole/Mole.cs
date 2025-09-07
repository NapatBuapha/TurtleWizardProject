using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Mole : MonoBehaviour
{
    GameObject playerObj;
    [SerializeField] private float startMove_Dis = 10;
    [SerializeField] private float playerDis;
    [SerializeField] private Animator animator;
    bool isAppear;
    void Start()
    {
        isAppear = false;
        playerObj = GameObject.FindWithTag("Player");
    }

    protected virtual void Update()
    {
        playerDis = Vector2.Distance(transform.position, playerObj.transform.position);
        if (playerDis < startMove_Dis)
        {
            animator.SetTrigger("Appear");
        }
    }
}
