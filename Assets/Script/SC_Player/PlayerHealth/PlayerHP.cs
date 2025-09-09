using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHP : MonoBehaviour, IDamageable
{
    public float maxHealth = 100f;
    private float health; //มีหน้าที่เก็บอย่างเดียวไม่ควรดึงไปใช้

    public float Health //เวลาจะเรียก ให้เรียกตัวนี้
    {
        get { return health; }
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
        }
    }

    //ใช้ตัวนี้เชื่อมกับ ui health 
    public float drainRate = 0.1f;
    bool isRunning;
    public bool isFatigue { get; private set; }
    [SerializeField] private float inviTimes;
    private bool isInvincibility;

    //Barrier code
    [Header ("Shield")]
    private bool isBarrier;
    private float barrierDuration;
    [SerializeField] private Animator anim;
    PlayerStateManager player;
    [SerializeField] private float stunDura_;
    [SerializeField] private GameObject barrier;
    private Coroutine invincibleCoroutine;


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
        barrier.SetActive(false);
    }


    public void getDamage(int damageValue)
    {
        if (!isInvincibility)
        {
            if (isBarrier)
            {
                isBarrier = false;
                barrierDuration = 0;
                StartTheInvincibelState(inviTimes);


            }
            else
            {
                AudioManager.PlaySound(SoundType.PLAYER_Hurt , 0.5f);
                anim.SetTrigger("Damaged");
                Health -= damageValue;
                StartCoroutine(Stun(stunDura_));
                StartTheInvincibelState(inviTimes);
            }
        }
    }

    public void Heal(float healValue)
    {
        Health += healValue;
    }

    private void Update()
    {
        if (Health <= 0 && isRunning)
        {
            isFatigue = true;
        }

        if (barrierDuration > 0) barrier.SetActive(true);
        else barrier.SetActive(false);
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isFatigue && isRunning)
            Health -= drainRate;

        if (barrierDuration > 0)
            barrierDuration -= Time.deltaTime;
        else
            isBarrier = false;
    }

    public void StartRunning()
    {
        Health = maxHealth;
        isRunning = true;
    }

    public void StartTheInvincibelState(float invincibilityTimes)
    {
        if (invincibleCoroutine != null)
        {
            StopCoroutine(invincibleCoroutine);
            invincibleCoroutine = StartCoroutine(InvincibleStates(invincibilityTimes));
        }
        else invincibleCoroutine = StartCoroutine(InvincibleStates(invincibilityTimes));
    }

    public IEnumerator InvincibleStates(float invincibilityTimes)
    {
        if (!anim.GetBool("WaterCast"))
            anim.SetBool("IsInvi", true);

        Physics2D.IgnoreLayerCollision(
        LayerMask.NameToLayer("Player"),
        LayerMask.NameToLayer("InvisFloor"),
        false);

        isInvincibility = true;
        yield return new WaitForSeconds(invincibilityTimes);
        isInvincibility = false;

        if (anim.GetBool("WaterCast")) anim.SetBool("WaterCast", false);
        else anim.SetBool("IsInvi", false);

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
        if(!player.isRushing)
        player.speed = baseSpeed;

    }


    public void GainBarrier(float duration)
    {
        barrierDuration = duration;
        isBarrier = true;
    }
}
