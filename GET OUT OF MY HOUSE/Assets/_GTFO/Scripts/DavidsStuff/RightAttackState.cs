using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightAttackState : State
{
    public RightRecoveryState recoveryState;
    public Animator enemyAnimator;
    public FightingMode player;
    public override State RunCurrentState()
    {
        enemyAnimator.ResetTrigger("startAttack");
        // Damage the player
        if (!player.isDodgeLeft)
        {
            // Damage player
        }
        enemyAnimator.SetTrigger("startRecovery");
        return recoveryState;
    }
    public override void Hit()
    { }
}
