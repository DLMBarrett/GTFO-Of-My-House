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
    public override State RunCurrentState()
    {
        chosenTime = Random.Range(minTime, maxTime);
        Wait();
        if (isHit)
        {
            if (Random.value < 0.5f)
            {
                return blockState;
            }
            else
            {
                return staggerState;
            }
        }
        if (Random.value < 0.5f)
        {
            return rightWindupState;
        }
        else
        {
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
