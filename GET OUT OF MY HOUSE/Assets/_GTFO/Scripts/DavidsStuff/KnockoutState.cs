using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockoutState : State
{
    public IdleState idleState;
    public override State RunCurrentState()
    {
        // Dizzy animation
        // When bashed then ragdoll
        // Countdown timer?
        // Getup Animation
        // Walk to new node
        return idleState;
    }
}
