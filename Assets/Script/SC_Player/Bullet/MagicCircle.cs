using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    [SerializeField] private int damageAmout = 2;
    [SerializeField] private float despawnTime;

    void Start()
    {
        Destroy(gameObject, despawnTime);
    }
    void OnTriggerStay2D(Collider2D col)
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
