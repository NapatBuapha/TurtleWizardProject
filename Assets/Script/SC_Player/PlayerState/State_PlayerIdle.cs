using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_PlayerIdle : PlayerBaseState
{

    // Start is called before the first frame update
    public override void EnterState(PlayerStateManager player)
    {
        player.animator.SetTrigger("Idle");
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {

    }
}
