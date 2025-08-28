using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    private float baseSpeed, baseGravity;
    int incresed_Stage;
    bool isAtMaxStage;
    bool isStopping;

    //Must have the same size
    [SerializeField] private float[] speed_Multiplier, gravity_Multiplier;

    PlayerStateManager player;
    Rigidbody2D playerRB;

    [SerializeField] private float increaseCountdown;
    [SerializeField] private float MaxCountdown;

    [SerializeField] GameObject speed_IncreasePopup;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerStateManager>();
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        baseSpeed = player.speed;
        baseGravity = playerRB.gravityScale;
    }

    void Start()
    {
        isStopping = true;
        increaseCountdown = 0;
        isAtMaxStage = false;
        incresed_Stage = 0;
    }

    void Update()
    {
        if (!isAtMaxStage && !isStopping)
        {
            if (increaseCountdown <= MaxCountdown)
            {
                increaseCountdown += Time.deltaTime;
            }
            else
            {
                IncreaseSpeed();
            }
        }

    }

    void IncreaseSpeed()
    {
        //reset countdown
        increaseCountdown = 0;

        //Increase Speed Stage
        if (incresed_Stage < speed_Multiplier.Length)
        {
            speed_IncreasePopup.SetActive(true);
            player.speed *= speed_Multiplier[incresed_Stage];
            playerRB.gravityScale *= gravity_Multiplier[incresed_Stage];
            incresed_Stage++;
        }
        else
        {
            isAtMaxStage = true;
        }
    }

    void ResetValue()
    {
        player.speed = baseSpeed;
        playerRB.gravityScale = baseGravity;
        incresed_Stage = 0;
    }

    public void StartRunning()
    {
        isStopping = false;
    }


}
