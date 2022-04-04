using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public float minTime = 1.0f, maxTime = 5.0f;
    public BlockState blockState;
    public StaggerState staggerState;
    public RightWindupState rightWindupState;
    public LeftWindupState leftWindupState;
    public bool isHit = false;
    public Animator enemyAnimator;
    private float chosenTime;
    private float timer = 0.0f;

    public override void Hit()
    {
        isHit = true;
    }

    public override State RunCurrentState()
    {
        enemyAnimator.ResetTrigger("isIdle");
        chosenTime = Random.Range(minTime, maxTime);
        Wait();
        if (isHit)
        {
            if (Random.value < 0.5f)
            {
                enemyAnimator.SetBool("isBlocking", true);
                return blockState;
            }
            else
            {
                enemyAnimator.SetTrigger("startStun");
                return staggerState;
            }
        }
        if (Random.value < 0.5f)
        {
            enemyAnimator.SetTrigger("startRight");
            return rightWindupState;
        }
        else
        {
            enemyAnimator.SetTrigger("startLeft");
            return leftWindupState;
        }
    }
    IEnumerator Wait()
    {
        // stand idle for chosenTime seconds
        Debug.Log("Waiting for " + chosenTime + " seconds.");
        if (isHit)
        {
            yield return null;
        }
        yield return new WaitForSeconds(chosenTime);
    }
}
