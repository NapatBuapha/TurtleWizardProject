using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ANA_Player : MonoBehaviour
{
    public Animator animator;

    //unity ads
    public GameOverUi GameOverUi;
    public static int AdOpportunity = 0;
    public static int AdCompleted = 0;

    //win-lose
    public string FailedReason = "-";
    public int LevelId = 1;
    public static int WinCounter = 0;
    public static int LoseCounter = 0;

    bool hasDied = false;

    //store


    void Start()
    {
        FailedReason = "-";
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

            //send data here
        }

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
}
