using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHP : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 20f;
    public float health;
    //*public float drainRate = 0.1f;
    public bool isFatigue { get; private set; }
    private bool isRunning;
    [SerializeField] private float inviTimes;
    private bool isInvincibility;

    // Start is called before the first frame update

    void Start()
    {
        isInvincibility = false;
        isRunning = false;
        isFatigue = false;
    }

    public void getDamage(int damageValue)
    {
        if (!isInvincibility)
        {
            health -= damageValue;
            StartCoroutine(InvincibleStates(inviTimes));
        }
        
    }

    private void Update()
    {
        if (health <= 0)
        {
            health = 0;
            isFatigue = true;
            isRunning = false;

        }
    }

    // Update is called once per frame
    /*private void FixedUpdate()
    {
        if (!isFatigue && isRunning)
            health -= drainRate;
    }*/

    public void StartRunning()
    {
        health = maxHealth;
        isRunning = true;
    }

    IEnumerator InvincibleStates(float invincibilityTimes)
    {
        isInvincibility = true;
        yield return new WaitForSeconds(invincibilityTimes);
        isInvincibility = false;
    }
}
