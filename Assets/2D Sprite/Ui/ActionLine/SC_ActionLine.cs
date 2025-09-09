using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ActionLine : MonoBehaviour
{
    public Animator animator;

    public void Start()
    {
        SetLineState(2);
    }

    public void SetLineState(int state)
    {

        animator.SetInteger("State", state);
    }
}
