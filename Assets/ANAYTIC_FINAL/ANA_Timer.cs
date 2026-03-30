using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ANA_Timer : MonoBehaviour
{
    public TextMeshProUGUI ANA_Timer_text;
    public float duration = 5f;
    private float currentTime;

    public GameObject ReviveButton;
    public bool isEnded = false;

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
            }
        }
        else
        {
            return;
        }
    }
}
