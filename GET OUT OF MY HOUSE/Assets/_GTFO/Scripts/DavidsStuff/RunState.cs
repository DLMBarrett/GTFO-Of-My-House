using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    public Animator enemyAnimator;
    public IdleState idleState;
    public override void Hit()
    {

    }

    public override State RunCurrentState()
    {
        enemyAnimator.ResetTrigger("isRunning");
        enemyAnimator.SetTrigger("isIdle");
        return idleState;
    }
}
