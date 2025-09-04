using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHP : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 20f;
    public float health;
    public float drainRate = 0.1f;
    bool isRunning;
    public bool isFatigue { get; private set; }
    [SerializeField] private float inviTimes;
    private bool isInvincibility;

    //Barrier code
    private bool isBarrier;
    private float barrierDuration;

    // Start is called before the first frame update

    void Start()
    {
        Physics2D.IgnoreLayerCollision(
        LayerMask.NameToLayer("Player"),
        LayerMask.NameToLayer("InvisFloor"),
        true);

        isInvincibility = false;
        isFatigue = false;
        isRunning = false;
        isBarrier = false;
    }


    public void getDamage(int damageValue)
    {
        if (!isInvincibility)
        {
            if (isBarrier)
            {
                isBarrier = false;
                barrierDuration = 0;
                StartCoroutine(InvincibleStates(inviTimes));

            }
            else
            {
                health -= damageValue;
                StartCoroutine(InvincibleStates(inviTimes));
            }
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            health = 0;
            isFatigue = true;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isFatigue && isRunning)
            health -= drainRate;

        if (barrierDuration > 0)
            barrierDuration -= Time.deltaTime;
        else
            isBarrier = false;
    }

    public void StartRunning()
    {
        health = maxHealth;
        isRunning = true;
    }

    public IEnumerator InvincibleStates(float invincibilityTimes)
    {
        Physics2D.IgnoreLayerCollision(
        LayerMask.NameToLayer("Player"),
        LayerMask.NameToLayer("InvisFloor"),
        false);
        isInvincibility = true;
        yield return new WaitForSeconds(invincibilityTimes);
        isInvincibility = false;
        Physics2D.IgnoreLayerCollision(
        LayerMask.NameToLayer("Player"),
        LayerMask.NameToLayer("InvisFloor"),
        true);
    }

    public void GainBarrier(float duration)
    {
        barrierDuration = duration;
        isBarrier = true;
    }
}
