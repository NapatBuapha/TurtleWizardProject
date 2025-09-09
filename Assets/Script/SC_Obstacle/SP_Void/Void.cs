using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    [SerializeField] private int damageAmout = 20;
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject hitObj = col.gameObject;
        
        if (hitObj.CompareTag("Player"))
        {
            hitObj.GetComponent<PlayerHP>().Health = 0;
        }
    }
}
