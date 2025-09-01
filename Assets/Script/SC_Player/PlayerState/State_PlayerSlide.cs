using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_PlayerSlide : PlayerBaseState
{
    Rigidbody2D rb;
    public override void EnterState(PlayerStateManager player)
    {
        player.animator.SetTrigger("Slide");
        rb = player.rb;
        player.ChangeHitbox_SlideState();
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
            player.ChangeHitbox_SlideState();
            player.SwitchState(player.state_PlayerShooting);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            player.ChangeHitbox_SlideState();
            player.SwitchState(player.state_PlayerJumping);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            player.ChangeHitbox_SlideState();
            player.SwitchState(player.state_PlayerRunning);
        }
    }


}
