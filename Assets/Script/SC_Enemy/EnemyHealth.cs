using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 2;
    [SerializeField] private int health;
    [SerializeField] private int onDefeatScore = 5;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void getDamage(int damageValue)
    {
        health -= damageValue;
        if (health <= 0)
        {
            GetDefeated();
        }
    }

    public void GetDefeated()
    {
        GameObject.Find("[Temp]ScoreDisplayer").GetComponent<ScoreDisplayUi>().IncreaseScore(onDefeatScore);
        Destroy(gameObject);
    }
    

}
