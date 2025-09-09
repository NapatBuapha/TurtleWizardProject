using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class BGChangeObj : MonoBehaviour
{
    [Range(1, 3)]
    [SerializeField] private int level;
    BGController bg;

    void Start()
    {
        bg = GameObject.Find("BGManager").GetComponent<BGController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            StartCoroutine(bg.ChangeIntoScene(level));
    }
}
