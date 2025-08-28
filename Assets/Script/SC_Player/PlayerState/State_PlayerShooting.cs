using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_PlayerShooting : PlayerBaseState
{
    private float stateDuration = 0.3f;
    private float currentStateDu;
    //private float currentCharge;
    private bool isCharging;
    public override void EnterState(PlayerStateManager player)
    {
        player.currentCharge = 0f;
        currentStateDu = 0;
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        if (!isCharging)
        {
            if (currentStateDu < stateDuration)
            {
                currentStateDu += Time.deltaTime;
            }
            else
            {
                ReturnToOtherStates(player);
            }
        }
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (Input.GetKey(KeyCode.X))
        {
            isCharging = true;
            
            if (player.currentCharge < player.maxCharge)
            {
                player.currentCharge += player.chargingRate * Time.deltaTime;
            }
            
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            isCharging = false;
            if (player.currentCharge >= player.maxCharge)
            {
                player.shooting();
                ReturnToOtherStates(player);
            }
            else
            {
                ReturnToOtherStates(player);
            }
        }
    }

    public void ReturnToOtherStates(PlayerStateManager player)
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
