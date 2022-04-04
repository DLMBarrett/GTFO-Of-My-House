using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWindupState : State
{
    public RightAttackState attackState;
    public Animator enemyAnimator;
    public float animTime = 0.625f;
    public override State RunCurrentState()
    {
        enemyAnimator.ResetTrigger("startRight");
        enemyAnimator.SetTrigger("startAttack");
        return attackState;
    }
    public override void Hit()
    { }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(animTime);
    }
}
