using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject winUi;
    public ANA_Player ANA_Player;
    void Awake()
    {
        winUi.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject hitObj = col.gameObject;

        if (hitObj.CompareTag("Player"))
        {
            hitObj.GetComponent<PlayerStateManager>().SetIdle();
            ANA_Player.OnWin();
            winUi.SetActive(true);
        }
    }
}
