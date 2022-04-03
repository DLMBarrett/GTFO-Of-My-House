using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandState : State
{
    public Animator enemyAnimator;
    public RunState runState;
    public override void Hit()
    {
        
    }

    public override State RunCurrentState()
    {
        enemyAnimator.ResetTrigger("isStanding");
        enemyAnimator.SetTrigger("isRunning");
        return runState;
    }
}
