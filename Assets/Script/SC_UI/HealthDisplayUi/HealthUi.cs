using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour
{
    private float ui_Health;
    [SerializeField] private PlayerHP playerHP;
    [SerializeField] private Slider hpSlider;

    void Start()
    {
        playerHP = GameObject.FindWithTag("Player").GetComponent<PlayerHP>();
        hpSlider.maxValue = playerHP.maxHealth;
    }

    void Update()
    {
        hpSlider.value = playerHP.Health;
        
    }

}
