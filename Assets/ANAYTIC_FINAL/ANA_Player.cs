using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;

public class ANA_Player : MonoBehaviour
{
    public Animator animator;

    //unity ads
    public GameOverUi GameOverUi;
    public int AdOpportunity = 0;
    public bool AdCompleted = false;

    //win-lose
    public string FailedReason = "-";
    public int LevelId = 1;
    public static int WinCounter = 0;
    public static int LoseCounter = 0;

    bool hasDied = false;

    //store
    public int PurchaseTracker = 0;
    public PlayerHP PlayerHP;
    public int coinLeft = 10;
    public bool hasEnoughCoin = true;
    public TextMeshProUGUI textMeshProUGUI;
    public GameObject ShopMenu;
    public bool Switch = true;

    void Start()
    {
        Initialize();
        FailedReason = "-";
    }

    private async void Initialize()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
    }

    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //track level
        switch (other.tag)
        {
            case "Level1":
                Debug.Log("Entered Level1");
                LevelId = 1;
                break;

            case "Level2":
                Debug.Log("Entered Level2");
                LevelId = 2;
                break;

            case "Level3":
                Debug.Log("Entered Level3");
                LevelId = 3;
                break;

        //track failed reason
            case "Enemy":
                FailedReason = "Obstacles";
                Debug.Log(FailedReason);
                break;

            case "Void":
                FailedReason = "Void";
                Debug.Log(FailedReason);
                break;
        }
    }

    public void OnWin()
    {
        FailedReason = "-";
        Debug.Log(FailedReason);

        WinCounter += 1;
        Debug.Log("WWWWWIIIIIINNNNN NAJA");
        Debug.Log("WinCounter :" + WinCounter);

        //send data here
        CustomEvent exampleEvent = new CustomEvent("ANA_WinTracker")
        {

        };
        AnalyticsService.Instance.RecordEvent(exampleEvent);
    }

    public void OnPlayerDeath()
    {
        if (hasDied) return;
        hasDied = true;

        LoseCounter += 1;

        if (FailedReason == "-")
        {
            FailedReason = "Zero HP";
            Debug.Log(FailedReason);
        }

        //send data here
        CustomEvent exampleEvent = new CustomEvent("ANA_LoseTracker")
            {
                {"Analytics_Final_FailedReason", FailedReason} ,
                {"Analytics_Final_LevelID", LevelId}
            };
        AnalyticsService.Instance.RecordEvent(exampleEvent);

        Debug.Log("LLLLLOOOOOOOSSSSSSEEEEEE NAJA");
        Debug.Log("LoseCounter :" + LoseCounter);
    }

    public void AdOpportunityTracker()
    {
        if (GameOverUi.isActive == true)
        {
            AdOpportunity++;
            Debug.Log("Ad Opportunity : " + AdOpportunity);
        }
    }

    public void PurchaseItem()
    {
        if(coinLeft >= 3)
        {
            coinLeft -= 3;
            textMeshProUGUI.text = "coin left : " + coinLeft;
            PurchaseTracker++;
            PlayerHP.maxHealth += 20;
            Debug.Log($"player purchased {PurchaseTracker} item");
        }
        else
        {
            Debug.Log("not enough coin");
        }
    }

    public void ExitShop()
    {
        if (!ShopMenu.activeInHierarchy)
        {
            Debug.Log("exit shop");
            
            //send data here
            CustomEvent exampleEvent = new CustomEvent("ANA_Store")
            {
                {"Analytics_Final_ItemName", "Add 20 Max Health"} ,
                {"Analytics_Final_NumOfPurchase", PurchaseTracker}
            };
            AnalyticsService.Instance.RecordEvent(exampleEvent);
        }
    }
}