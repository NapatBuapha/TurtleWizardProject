using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaObj : MonoBehaviour
{

    [SerializeField] public ManaColor color;
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject hitObj = col.gameObject;

        if (hitObj.CompareTag("Player"))
        {
            ManaPaletteCore palette = hitObj.GetComponent<ManaPaletteCore>();
            palette.AddMana(color);
            Destroy(gameObject);
        }
    }
}



