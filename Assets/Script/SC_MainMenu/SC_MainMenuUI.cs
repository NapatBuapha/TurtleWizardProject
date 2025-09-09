using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenuUI : MonoBehaviour
{
    [Header("UI References")]
    public GameObject mainMenuPanel; // Panel ที่เก็บปุ่มและโลโก้

    void Start()
    {
        // หยุดเวลาไว้ก่อน (ถ้าอยากให้เกมรอกด Start)
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        // ซ่อนเมนู
        mainMenuPanel.SetActive(false);

        // ปล่อยเวลาให้เกมทำงาน
        Time.timeScale = 1f;

        Debug.Log("Game Started!");
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();

        // เวลาเทสใน Unity Editor มันจะไม่ปิด Editor ต้อง build ออกมาก่อนถึงจะทำงาน
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}