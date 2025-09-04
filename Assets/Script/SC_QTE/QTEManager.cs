using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject qtePanel;              
    public Image arrowPrefab;                
    public Sprite upArrow, downArrow, leftArrow, rightArrow; 
    public Transform arrowContainer;         

    private List<KeyCode> currentSequence = new List<KeyCode>();
    private int currentIndex = 0;
    private bool isQTEActive = false;

    PlayerStateManager player;

    void Start()
    {
        if (qtePanel != null)
            qtePanel.SetActive(false);
        player = GameObject.FindWithTag("Player").GetComponent<PlayerStateManager>();
    }

    public void StartQTE()
    {
        if (isQTEActive) return;

        qtePanel.SetActive(true);
        isQTEActive = true;
        currentSequence.Clear();
        currentIndex = 0;

        GenerateSequence();
        ShowSequence();
    }

    void Update()
    {
        if (!isQTEActive) return;

        if (currentIndex < currentSequence.Count)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                CheckPlayerInput();
            if (Input.GetKeyDown(KeyCode.DownArrow))
                CheckPlayerInput();
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                CheckPlayerInput();
            if (Input.GetKeyDown(KeyCode.RightArrow))
                CheckPlayerInput();
        }
    }

    void CheckPlayerInput()
    {
        if (Input.GetKeyDown(currentSequence[currentIndex]))
            {
                // กดถูกได้ไร ไม่รู้
                arrowContainer.GetChild(currentIndex).GetComponent<Image>().color = Color.black;
                currentIndex++;

                if (currentIndex >= currentSequence.Count)
                {
                    QTESuccess();
                }
            }
            else if (Input.anyKeyDown)
            {
                // กดผิด เกิดอะไร
                QTEFail();
            }
    }

    void GenerateSequence()
    {
        int length = Random.Range(3, 7); // สุ่ม 3 - 6 ตัว

        for (int i = 0; i < length; i++)
        {
            int rnd = Random.Range(0, 4);
            switch (rnd)
            {
                case 0: currentSequence.Add(KeyCode.UpArrow); break;
                case 1: currentSequence.Add(KeyCode.DownArrow); break;
                case 2: currentSequence.Add(KeyCode.LeftArrow); break;
                case 3: currentSequence.Add(KeyCode.RightArrow); break;
            }
        }

        Debug.Log("QTE Sequence Length = " + currentSequence.Count);
    }

    void ShowSequence()
    {
        foreach (Transform child in arrowContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (KeyCode key in currentSequence)
        {
            Image arrow = Instantiate(arrowPrefab, arrowContainer);

            switch (key)
            {
                case KeyCode.UpArrow: arrow.sprite = upArrow; break;
                case KeyCode.DownArrow: arrow.sprite = downArrow; break;
                case KeyCode.LeftArrow: arrow.sprite = leftArrow; break;
                case KeyCode.RightArrow: arrow.sprite = rightArrow; break;
            }

            arrow.color = Color.white;
        }
        
    }

    void QTESuccess()
    {
        Debug.Log("QTE Success!");
        qtePanel.SetActive(false);
        isQTEActive = false;
    }

    void QTEFail()
    {
        Debug.Log("QTE Failed!");
        qtePanel.SetActive(false);
        isQTEActive = false;
    }
}
