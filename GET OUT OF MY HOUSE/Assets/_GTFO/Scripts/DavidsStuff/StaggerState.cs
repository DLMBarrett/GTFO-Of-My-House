using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaggerState : State
{
    public override State RunCurrentState()
    {
        return this;
    }
}
