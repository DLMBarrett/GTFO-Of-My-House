using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaggerState : State
{
    public Animator enemyAnimator;
    public Health enemyHealth;
    public IdleState idleState;
    public KnockoutState knockoutState;
    public float staggerTime = 5.0f;
    public int maxPunches = 4;
    private float currTimer = 0;
    private int currPunches = 0;
    public override State RunCurrentState()
    {
        enemyAnimator.ResetTrigger("startStun");
        enemyAnimator.SetTrigger("isDizzy");
        enemyAnimator.ResetTrigger("isDizzy");
        Wait();
        if (enemyHealth.GetHealth() == 0)
        {
            enemyAnimator.SetTrigger("startKnockout");
            return knockoutState;
        }
        enemyAnimator.SetTrigger("isIdle");
        return idleState;
    }
    public override void Hit()
    {
        enemyHealth.Damage();
        currPunches++;
    }
    IEnumerator Wait()
    {
        // stand idle for chosenTime seconds
        Debug.Log("Staggered for " + staggerTime + " seconds.");
        if (currPunches == maxPunches)
        {
            currPunches = 0;
            yield return null;
        }
        yield return new WaitForSeconds(staggerTime);
    }
}
