using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverUi : MonoBehaviour
{
    [SerializeField] private GameObject uiGroup;
        void Start()
    {
        uiGroup.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Reset");
    }

        public void GameOver()
    {
        uiGroup.SetActive(true);
    }

    public void BackToMain()
    {
        Debug.Log("Back to mainmenu");
    }
}
