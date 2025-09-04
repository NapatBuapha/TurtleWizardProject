using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestructionAura : MonoBehaviour
{
    int damage = 1;
    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject hitObj = col.gameObject;

        if (hitObj.CompareTag("Enemy"))
        {
            IDamageable damageable = hitObj.GetComponent<IDamageable>();
            damageable.getDamage(damage);
        }
    }
}
