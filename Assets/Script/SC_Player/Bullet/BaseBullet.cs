using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    [SerializeField] int damageAmout = 2;
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject hitObj = col.gameObject;

        if (hitObj.CompareTag("Enemy"))
        {
            IDamageable damageable = hitObj.GetComponent<IDamageable>();
            damageable.getDamage(damageAmout);
            Destroy(gameObject);
        }
    }
}
