using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindupState : State
{
    public AttackState attackState;
    public override State RunCurrentState()
    {
        return attackState;
    }
}
