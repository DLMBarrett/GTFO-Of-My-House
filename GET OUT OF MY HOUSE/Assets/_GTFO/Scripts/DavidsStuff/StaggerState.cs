using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaggerState : State
{
    public Animator enemyAnimator;
    public override State RunCurrentState()
    {
        return this;
    }
}
