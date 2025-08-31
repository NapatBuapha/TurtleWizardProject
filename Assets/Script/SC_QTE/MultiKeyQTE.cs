using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiKeyQTE : MonoBehaviour
{
    public GameObject qteUI;     // UI Panel
    public TMP_Text qteText;     // แสดงปุ่มที่ต้องกด

    private KeyCode[] possibleKeys = { KeyCode.U, KeyCode.H, KeyCode.J, KeyCode.K };
    private KeyCode[] currentSequence;
    private int currentIndex = 0;

    private bool playerInZone = false;
    private bool qteActive = false;



    void Start()
    { 
            qteUI.SetActive(true);
            qteText.text = "Code ติดไหมเห้ยย";
  
        qteUI.SetActive(false);
    }

    void Update()
    {
        if (qteActive)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(currentSequence[currentIndex]))
                {
                    Debug.Log("Correct Key: " + currentSequence[currentIndex]);
                    currentIndex++;

                    if (currentIndex >= currentSequence.Length)
                    {
                        //GameObject.FindWithTag("Player").GetComponent<PlayerStateManager>().GrandCasting();
                        Debug.Log("QTE Success!");
                        QTESuccess();
                    }
                    else
                    {
                        UpdateUIText();
                    }
                }
                else
                {
                    // ยังไม่ได้ให้ทำอะไร
                    Debug.Log("Wrong Key!");
                    QTEFail();
                }
            }
        }
    }

    private void StartQTE()
    {
        // สุ่มลำดับปุ่ม (จำนวน 4 ปุ่มทั้งหมด)
        currentSequence = ShuffleArray(possibleKeys);
        currentIndex = 0;

        qteUI.SetActive(true);
        qteActive = true;
        UpdateUIText();
    }

    private void UpdateUIText()
    {
        string seq = "";
        for (int i = 0; i < currentSequence.Length; i++)
        {
            if (i == currentIndex)
                seq += "<color=yellow>" + currentSequence[i] + "</color> ";
            else
                seq += currentSequence[i] + " ";
        }
        qteText.text = "Press: " + seq;
    }

    private void QTESuccess()
    {
        qteUI.SetActive(false);
        qteActive = false;
    }

    private void QTEFail()
    {
        qteUI.SetActive(false);
        qteActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            if (!qteActive)
                StartQTE();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            qteUI.SetActive(false);
            qteActive = false;
        }
    }

    // ฟังก์ชันสลับลำดับแบบสุ่ม (Fisher-Yates shuffle)
    private KeyCode[] ShuffleArray(KeyCode[] array)
    {
        KeyCode[] newArray = (KeyCode[])array.Clone();
        for (int i = newArray.Length - 1; i > 0; i--)
        {
            int rnd = Random.Range(0, i + 1);
            KeyCode temp = newArray[i];
            newArray[i] = newArray[rnd];
            newArray[rnd] = temp;
        }
        return newArray;
    }
}
