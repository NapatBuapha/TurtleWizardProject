using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class State_PlayerRunning : PlayerBaseState
{
    Rigidbody2D rb;

    public override void EnterState(PlayerStateManager player)
    {

        rb = player.rb;
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        rb.velocity = new Vector2(player.speed,rb.velocity.y);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.isFatigue)
        {
            player.gameOver.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            player.SwitchState(player.state_PlayerShooting);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            player.SwitchState(player.state_PlayerJumping);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            player.SwitchState(player.state_PlayerSlide);
        }
    }
}
