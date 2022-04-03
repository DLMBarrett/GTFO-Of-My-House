using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightAttackState : State
{
    public RightRecoveryState recoveryState;
    public GameObject player;
    public Animator enemyAnimator;
    public override State RunCurrentState()
    {
        // Damage the player
        //player.damage();
        return this;
    }
}
