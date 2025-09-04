using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class State_PlayerInAir : PlayerBaseState
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log(this);
        rb = player.rb;

    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        rb.velocity = new Vector2(player.speed, rb.velocity.y);
    }

    public override void UpdateState(PlayerStateManager player)
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            player.UseMagic();
        }

        if (Input.GetKeyDown(KeyCode.Z) && player.canDoubleJump)
        {
            player.canDoubleJump = false;
            player.SwitchState(player.state_PlayerJumping);
        }

        if (player.isGround)
        {
            if (Input.GetKey(KeyCode.C))
            {
                player.SwitchState(player.state_PlayerSlide);
            }
            else
            {
                player.SwitchState(player.state_PlayerRunning);
            }

        }
    }
}

