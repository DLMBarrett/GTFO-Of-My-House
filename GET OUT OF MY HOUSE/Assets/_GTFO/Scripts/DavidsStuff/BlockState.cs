using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : State
{
    public IdleState idleState;
    public override State RunCurrentState()
    {
        return idleState;
    }
}
