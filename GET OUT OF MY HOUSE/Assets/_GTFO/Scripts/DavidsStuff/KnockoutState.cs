using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockoutState : State
{
    public StandState standState;
    public Animator animator;

    public override void Hit()
    {
        
    }

    public override State RunCurrentState()
    {
        animator.ResetTrigger("startKnockout");
        // Dizzy animation
        // When bashed then ragdoll
        // Countdown timer?
        // Getup Animation
        // Walk to new node
        animator.SetTrigger("isStanding");
        return standState;
    }
}
