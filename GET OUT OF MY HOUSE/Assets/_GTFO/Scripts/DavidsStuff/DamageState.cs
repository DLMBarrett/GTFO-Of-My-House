using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageState : State
{
    public IdleState idleState;
    public KnockoutState knockoutState;
    public Animator enemyAnimator;
    public GameObject Enemy;
    public override State RunCurrentState()
    {
        // remove hp from enemy health
        
        return this;
    }
}
