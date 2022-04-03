using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAttackState : State
{
    public LeftRecoveryState recoveryState;
    public GameObject player;
    public Animator enemyAnimator;
    public override State RunCurrentState()
    {
        // Damage the player
        //player.damage();
        return this;
    }
}
