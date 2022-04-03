using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : State
{
    public IdleState idleState;
    public Animator animator;

    public override void Hit()
    {
        
    }

    public override State RunCurrentState()
    {
        animator.SetBool("isBlocking", false);
        return idleState;
    }
}
