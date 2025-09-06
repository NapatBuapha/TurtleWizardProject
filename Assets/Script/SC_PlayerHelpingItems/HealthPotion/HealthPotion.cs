using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float healAmouth = 20;
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject hitObj = col.gameObject;

        if (hitObj.CompareTag("Player"))
        {
            hitObj.GetComponent<PlayerHP>().Heal(healAmouth);
            Destroy(gameObject);
        }
    }
}
