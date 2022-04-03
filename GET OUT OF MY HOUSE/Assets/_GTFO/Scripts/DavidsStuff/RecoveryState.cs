using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryState : State
{
    public StaggerState staggerState;
    public IdleState idleState;
    public bool isHit = false;
    public override State RunCurrentState()
    {
        if (isHit)
        {
            return staggerState;
        }
        return idleState;
    }
}
