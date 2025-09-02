using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTETrigger2D : MonoBehaviour
{
    public QTEManager qteManager; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered QTE Zone!");
            qteManager.StartQTE();
        }
    }
}
