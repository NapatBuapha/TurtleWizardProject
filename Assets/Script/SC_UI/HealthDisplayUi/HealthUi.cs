using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class HealthUi : MonoBehaviour
{
    private float ui_Health;
    private PlayerHP playerHP;
    [SerializeField] private TMP_Text hpText;

    void Start()
    {
        playerHP = GameObject.FindWithTag("Player").GetComponent<PlayerHP>();
    }

    void Update()
    {
        ui_Health = playerHP.health;
        hpText.text = $"HP = {Math.Round(ui_Health, 2)}";

    }

}
