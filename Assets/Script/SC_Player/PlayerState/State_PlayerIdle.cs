using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_PlayerIdle : PlayerBaseState
{

    Rigidbody2D rb;
    // Start is called before the first frame update
    public override void EnterState(PlayerStateManager player)
    {
        rb = player.rb;
        player.animator.SetTrigger("Idle");
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        rb.velocity = new Vector2(0,rb.velocity.y);
    }

    public override void UpdateState(PlayerStateManager player)
    {

    }
}
