using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currState;
    public IdleState idleState;
    public bool startMachine;
    private void Start()
    {
        currState = idleState;
    }
    private void Update()
    {
        if (startMachine)
            RunStateMachine();
    }
    private void RunStateMachine()
    {
        State nextState = currState?.RunCurrentState();

        if (nextState != null)
        {
            // Switch to next state
            SwitchToNextState(nextState);
        }
    }

    private void SwitchToNextState(State nextState)
    {
        currState = nextState;
    }
}
