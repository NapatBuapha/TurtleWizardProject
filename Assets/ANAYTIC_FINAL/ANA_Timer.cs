using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Services.Analytics;
using Unity.Services.Core;

public class ANA_Timer : MonoBehaviour
{
    public TextMeshProUGUI ANA_Timer_text;
    public float duration = 5f;
    private float currentTime;

    public GameObject ReviveButton;
    public bool isEnded = false;

    public ANA_Player ANA_Player;

    public GameOverUi gameOverUi;

    void Start()
    {
        currentTime = duration;
    }

    void Update()
    {
        if (gameOverUi.isActive == true)
        {
            if (isEnded) return;

            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                ANA_Timer_text.text = Mathf.Ceil(currentTime).ToString();

                //Debug.Log(currentTime);
            }
            else
            {
                currentTime = 0;
                ANA_Timer_text.text = "0";

                Destroy(ReviveButton);
                isEnded = true;

                //send data here
                CustomEvent exampleEvent = new CustomEvent("ANA_UnityAd")
                {
                    {"Analytics_Final_AdOpportunity", ANA_Player.AdOpportunity} ,
                    {"Analytics_Final_AdCompleted", ANA_Player.AdCompleted}
                };
                AnalyticsService.Instance.RecordEvent(exampleEvent);
            }
        }
        else
        {
            return;
        }
    }
}
