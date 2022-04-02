using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : State
{
    public override State RunCurrentState()
    {
        return this;
    }
}
