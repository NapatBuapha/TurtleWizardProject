using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class State_PlayerGrandCasting : PlayerBaseState
{
    Rigidbody2D rb;
    float currentCastingDuration;
    float baseGravity;
    public override void EnterState(PlayerStateManager player)
    {
        Physics2D.IgnoreLayerCollision(
        LayerMask.NameToLayer("Player"),
        LayerMask.NameToLayer("Ground"),
       true);

        if (player.isSliding)
        {
            player.ChangeHitbox_SlideState();
        }

        currentCastingDuration = 0;
        rb = player.rb;
        baseGravity = rb.gravityScale;
        rb.gravityScale = 0;
        player.gameObject.GetComponent<GrandCasting>().isGrandCasting = true;
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        if (player.gameObject.transform.position.y < player.floatDistance)
        {
            player.gameObject.transform.position = Vector2.MoveTowards
            (player.gameObject.transform.position,
            new Vector2(player.gameObject.transform.position.x, player.floatDistance), player.floatVelocity * Time.deltaTime);
            
        }

            rb.velocity = new Vector2(player.CastingSpeed, rb.velocity.y);
        

        
    }

    public override void UpdateState(PlayerStateManager player)
    {

        if (currentCastingDuration < player.CastingMaxDuration)
        {
            currentCastingDuration += Time.deltaTime;
        }
        else
        {
            Physics2D.IgnoreLayerCollision(
            LayerMask.NameToLayer("Player"),
            LayerMask.NameToLayer("Ground"),
            false);
            player.gameObject.GetComponent<GrandCasting>().isGrandCasting = false;
            rb.gravityScale = baseGravity;
            player.SwitchState(player.state_PlayerRunning);
        }
    }
    
}
