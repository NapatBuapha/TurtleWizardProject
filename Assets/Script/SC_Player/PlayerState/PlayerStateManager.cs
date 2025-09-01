using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;


public class PlayerStateManager : MonoBehaviour
{

    PlayerBaseState currentState;
    public string playerStat;
    public State_PlayerIdle state_PlayerIdle { get; private set; } = new State_PlayerIdle();
    public State_PlayerRunning state_PlayerRunning { get; private set; } = new State_PlayerRunning();
    public State_PlayerJumping state_PlayerJumping { get; private set; } = new State_PlayerJumping();
    public State_PlayerInAir state_PlayerInAir { get; private set; } = new State_PlayerInAir();
    public State_PlayerShooting state_PlayerShooting { get; private set; } = new State_PlayerShooting();
    public State_PlayerFatigue state_PlayerFatigue { get; private set; } = new State_PlayerFatigue();
    public State_PlayerSlide state_PlayerSlide { get; private set; } = new State_PlayerSlide();
    public State_PlayerAirDash state_PlayerAirDash { get; private set; } = new State_PlayerAirDash();
    public State_PlayerGrandCasting state_PlayerGrandCasting { get; private set; } = new State_PlayerGrandCasting();


    [Header("Moving")]
    public int playerFacing;
    public float speed = 10;

    public Rigidbody2D rb { get; private set; }
    [Header("Jumping")]
    public float jumpPower = 10;
    public float jumpingTimeDelayed = 0.5f;
    public Vector2 groundCheckBoxSize = new Vector2(1f, 1f);
    public float boxCastDistance = 1f;
    public LayerMask groundLayer;
    public bool isGround;
    [Header("Shooting")]
    public GameObject magic;
    public float chargingRate;
    public float maxCharge;
    public float currentCharge;

    public IGunStyle gunStyle;
    [Header("FatigueStatus")]
    public bool isFatigue;
    public UnityEvent gameOver;
    [Header("Sliding")]
    [SerializeField] private BoxCollider2D playerCol;
    [SerializeField] private Vector2 slideColOffset, slideColSize;
    [SerializeField] private Vector2 normColOffset, normColSize;
    [SerializeField] private bool isSliding;

    [Header("AirDash")]
    public float airdashForce;
    public bool canAirDash;

    [Header("Grand Casting Stage")]
    public float CastingSpeed;
    public float CastingMaxDuration;
    public float floatVelocity;
    public float floatDistance;
    [Header("Animation")]
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        canAirDash = true;
        isSliding = false;
        gameOver.AddListener(GameObject.Find("[Temp]GameOverCanvas").GetComponent<GameOverUi>().GameOver);
        gameOver.AddListener(FatigueGameOver);
        //GameOver Event

        playerCol = GetComponent<BoxCollider2D>();
        gunStyle = magic.GetComponent<IGunStyle>();
        rb = GetComponent<Rigidbody2D>();
        currentState = state_PlayerIdle;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        isFatigue = GetComponent<PlayerHP>().isFatigue;
        isGround = CheckGround();
        currentState.UpdateState(this);
        playerStat = currentState.ToString();

    }

    void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public bool CheckGround()
    {
        if (Physics2D.BoxCast(transform.position, groundCheckBoxSize, 0, -Vector2.up, boxCastDistance, groundLayer))
        {
            canAirDash = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void shooting()
    {
        Debug.Log(gunStyle);
        gunStyle.shooting();
    }

    public void FatigueGameOver()
    {
        SwitchState(state_PlayerFatigue);
    }

    public void StartRunning()
    {
        SwitchState(state_PlayerRunning);
    }

    public void ChangeHitbox_SlideState()
    {
        switch (isSliding)
        {
            case true:
                isSliding = false;
                playerCol.offset = normColOffset;
                playerCol.size = normColSize;
                break;

            default:
                isSliding = true;
                playerCol.offset = slideColOffset;
                playerCol.size = slideColSize;
                break;
        }
    }

    public void GrandCasting()
    {
        SwitchState(state_PlayerGrandCasting);
    }

    
}
