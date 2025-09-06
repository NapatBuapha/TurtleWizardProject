using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScorableObj : MonoBehaviour
{
    [SerializeField] private int scoreAmouth = 5;
    ScoreDisplayUi scoreDisplayUi;

    void Start()
    {
        scoreDisplayUi = GameObject.Find("[Temp]ScoreDisplayer").GetComponent<ScoreDisplayUi>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject hitObj = col.gameObject;

        if (hitObj.CompareTag("Player"))
        {
            scoreDisplayUi.IncreaseScore(scoreAmouth);
            Destroy(gameObject);
        }
    }
}
