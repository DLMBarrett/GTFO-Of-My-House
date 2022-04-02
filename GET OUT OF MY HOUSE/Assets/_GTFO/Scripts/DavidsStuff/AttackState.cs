using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public RecoveryState recoveryState;
    public GameObject player;
    public override State RunCurrentState()
    {
        // Damage the player
        //player.damage();
        return this;
    }
}
