using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockoutState : State
{
    public StandState standState;
    public Animator animator;
    public bool isBashed = false;

    public override void Hit()
    {
        isBashed = true;
    }

    public override State RunCurrentState()
    {
        animator.ResetTrigger("startKnockout");
        isBashed = false;
        // Dizzy animation
        // When bashed then ragdoll
        Wait();
        // Countdown timer?
        animator.SetTrigger("isStanding");
        return standState;
    }

    IEnumerator Wait()
    {
        // stand idle for chosenTime seconds
        Debug.Log("Dizzy until bashed.");
        while (!isBashed)
        {
            yield return null;
        }
    }
}
