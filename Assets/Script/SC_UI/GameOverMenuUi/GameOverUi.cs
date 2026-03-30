using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.Analytics;
using Unity.Services.Core;


public class GameOverUi : MonoBehaviour
{
    [SerializeField] private GameObject uiGroup;

    //ANALYZE FINAL
    public ANA_Player ANA_Player;
    //

    public bool isActive = false;

        void Start()
    {
        uiGroup.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        ANA_Player.WinCounter = 0;
        ANA_Player.LoseCounter = 0;

        Debug.Log("Reset");
    }

        public void GameOver()
    {
        uiGroup.SetActive(true);
        isActive = true;
        ANA_Player.AdOpportunityTracker();
    }

    public void BackToMain()
    {
        Debug.Log("Back to mainmenu");
    }

    //ANALYZE FINAL
    public void ReviveButton()
    {
        Debug.Log("Revive Button Pressed");
        ANA_Player.AdCompleted = true;
        Debug.Log("Ad Completed : " + ANA_Player.AdCompleted);

        uiGroup.SetActive(false);
        isActive = false;

        //send data here
        CustomEvent exampleEvent = new CustomEvent("ANA_UnityAd")
        {
            {"Analytics_Final_AdOpportunity", ANA_Player.AdOpportunity} ,
            {"Analytics_Final_AdCompleted", ANA_Player.AdCompleted}
        };
        AnalyticsService.Instance.RecordEvent(exampleEvent);
    }

    public void ShopButton()
    {
        Debug.Log("Open Shop Menu");
    }
}
