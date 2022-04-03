using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageState : State
{
    public IdleState idleState;
    public KnockoutState knockoutState;
    public Animator enemyAnimator;
    public GameObject Enemy;
    public AudioManager audioManager;

    public override void Hit()
    {
        
    }

    public override State RunCurrentState()
    {
        // Play a random sound from the grunts
        //audioManager.Play()
        // remove hp from enemy health
        
        return this;
    }
}
