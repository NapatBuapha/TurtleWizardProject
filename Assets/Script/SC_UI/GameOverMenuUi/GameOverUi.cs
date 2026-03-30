using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        ANA_Player.AdCompleted++;
        Debug.Log("Ad Completed : " + ANA_Player.AdCompleted);

        uiGroup.SetActive(false);
        isActive = false;
    }

    public void ShopButton()
    {
        Debug.Log("Open Shop Menu");
    }
}
