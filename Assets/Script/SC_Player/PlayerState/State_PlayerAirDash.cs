using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_PlayerAirDash : PlayerBaseState
{
    Rigidbody2D rb;
    public override void EnterState(PlayerStateManager player)
    {
        player.canAirDash = false;
        rb = player.rb;
        rb.AddForce(new Vector2(player.airdashForce,0),ForceMode2D.Impulse);
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (rb.velocity.x <= player.speed)
        {
            player.SwitchState(player.state_PlayerInAir);
            
        }
        
        if (player.isGround)
            {
                player.SwitchState(player.state_PlayerRunning);
            }

    }
}

