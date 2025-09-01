using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_PlayerFatigue : PlayerBaseState
{
    Rigidbody2D rb;
    public override void EnterState(PlayerStateManager player)
    {
        player.animator.SetTrigger("Lose");
        rb = player.rb;
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        rb.velocity = new Vector2(0,rb.velocity.y);
    }

    public override void UpdateState(PlayerStateManager player)
    {

    }
}

