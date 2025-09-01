using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_PlayerJumping : PlayerBaseState
{
    Rigidbody2D rb;
    private float jumpCountdown;



    // Start is called before the first frame update
    public override void EnterState(PlayerStateManager player)
    {
        rb = player.rb;

        player.animator.SetTrigger("Jump");
        jumpCountdown = player.jumpingTimeDelayed;
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * player.jumpPower, ForceMode2D.Impulse);

        Debug.Log(this);
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        rb.velocity = new Vector2(player.speed, rb.velocity.y);
    }


    public override void UpdateState(PlayerStateManager player)
    {

            if (Input.GetKeyDown(KeyCode.X))
            {
                player.SwitchState(player.state_PlayerShooting);
            }
            if(Input.GetKeyUp(KeyCode.Z))
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                if (player.isGround)
                {
                    player.SwitchState(player.state_PlayerRunning);
                }
                else
                {
                    player.SwitchState(player.state_PlayerInAir);
                }
            }
           
            if (jumpCountdown >= 0)
            {
                jumpCountdown -= Time.deltaTime;
            }
            else
            {
                if (player.isGround)
                {
                    player.SwitchState(player.state_PlayerRunning);
                }
                else
                {
                    player.SwitchState(player.state_PlayerInAir);
                }
            }
    }
}



    
    

