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
    [SerializeField] private Animator anim;
    PlayerStateManager player;
    [SerializeField] private float stunDura_; 


    // Start is called before the first frame update

    void Start()
    {
        Physics2D.IgnoreLayerCollision(
        LayerMask.NameToLayer("Player"),
        LayerMask.NameToLayer("InvisFloor"),
        true);

        player = GetComponent<PlayerStateManager>();
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
                anim.SetTrigger("Damaged");
                health -= damageValue;
                StartCoroutine(Stun(stunDura_));
                StartCoroutine(InvincibleStates(inviTimes));
            }
        }
    }

    public void Heal(float healValue)
    {
        health += healValue;
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
        anim.SetBool("IsInvi", true);
        Physics2D.IgnoreLayerCollision(
        LayerMask.NameToLayer("Player"),
        LayerMask.NameToLayer("InvisFloor"),
        false);
        isInvincibility = true;
        yield return new WaitForSeconds(invincibilityTimes);
        isInvincibility = false;
        anim.SetBool("IsInvi", false);
        Physics2D.IgnoreLayerCollision(
        LayerMask.NameToLayer("Player"),
        LayerMask.NameToLayer("InvisFloor"),
        true);
    }

    public IEnumerator Stun(float stunDuration)
    {
        float baseSpeed = player.speed;
        player.speed *= 0.5f;
        yield return new WaitForSeconds(stunDuration);
        player.speed = baseSpeed;

    }


    public void GainBarrier(float duration)
    {
        barrierDuration = duration;
        isBarrier = true;
    }
}
