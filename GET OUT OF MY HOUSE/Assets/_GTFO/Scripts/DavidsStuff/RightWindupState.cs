using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWindupState : State
{
    public RightAttackState attackState;
    public Animator enemyAnimator;
    public override State RunCurrentState()
    {
        return attackState;
    }
}
