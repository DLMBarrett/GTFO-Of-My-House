using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWindupState : State
{
    public RightAttackState attackState;
    public Animator enemyAnimator;
    public override State RunCurrentState()
    {
        enemyAnimator.ResetTrigger("startLeft");
        enemyAnimator.SetTrigger("startAttack");
        return attackState;
    }
    public override void Hit()
    {}
}
