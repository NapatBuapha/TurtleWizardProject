using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTETrigger : MonoBehaviour
{
    public QTEManager qteManager; // อ้างอิงไปยัง QTEManager

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered QTE Zone!");
            qteManager.StartQTE();
        }
    }
}
