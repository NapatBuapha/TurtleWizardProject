using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBase : MonoBehaviour
{
    [SerializeField] int damageAmout = 2;
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject hitObj = col.gameObject;
        
        if (hitObj.CompareTag("Player"))
        {
            IDamageable damageable = hitObj.GetComponent<IDamageable>();
            damageable.getDamage(damageAmout);
        }
    }
}
