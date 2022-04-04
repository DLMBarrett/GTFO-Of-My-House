using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRecoveryState : State
{
    public StaggerState staggerState;
    public IdleState idleState;
    public bool isHit = false;
    public Animator enemyAnimator;
    public override State RunCurrentState()
    {
        enemyAnimator.ResetTrigger("startRecovery");
        if (isHit)
        {
            enemyAnimator.SetTrigger("startStun");
            return staggerState;
        }
        enemyAnimator.SetTrigger("isIdle");
        return idleState;
    }
    public override void Hit()
    {
        isHit = true;
    }
}
