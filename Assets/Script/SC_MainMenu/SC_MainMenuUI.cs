using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenuUI : MonoBehaviour
{
    [Header("UI References")]
    public GameObject mainMenuPanel; // Panel ที่เก็บปุ่มและโลโก้
    public GameObject hpSlider;

    void Start()
    {
        hpSlider.SetActive(false);
    }

    public void StartGame()
    {
        // ซ่อนเมนู
        mainMenuPanel.SetActive(false);
        // เปิด HpBar
        hpSlider.SetActive(true);

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