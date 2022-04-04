using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAttackState : State
{
    public LeftRecoveryState recoveryState;
    public FightingMode player;
    public Animator enemyAnimator;
    public override State RunCurrentState()
    {
        enemyAnimator.ResetTrigger("startAttack");

        // Damage the player
        // Damage the player
        if (!player.isDodgeRight)
        {
            // Damage player
        }
        enemyAnimator.SetTrigger("startRecovery");
        return recoveryState;
    }
    public override void Hit()
    { }
}
