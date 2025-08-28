using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class ScoreDisplayUi : MonoBehaviour
{
    [SerializeField] private int scorePoint;
    [SerializeField] private TMP_Text scoreText;

    void Start()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = $"Score = {scorePoint}";
    }

    public void IncreaseScore(int score)
    {
        scorePoint += score;
        UpdateScore();
    }

}
