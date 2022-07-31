using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitcaseStateManager : MonoBehaviour
{
    SuitcaseBaseState currentState;
    public SuitcaseIdleState IdleState = new SuitcaseIdleState();
    public SuitcaseInspectedState InspectedState = new SuitcaseInspectedState();
    public SuitcaseOpenState OpenState = new SuitcaseOpenState();
    public SuitcaseHandleUpState HandleUpState = new SuitcaseHandleUpState();

    // Start is called before the first frame update
    void Start()
    {
        // starting state for the suitcase
        currentState = IdleState;
        // "this" is a reference to the context (this EXACT Monobehavior script)
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(SuitcaseBaseState state)
    {
        // transition to the new state passed in
        currentState = state;
        // calls EnterState logic from the new state one time
        state.EnterState(this);
    }

    public void SwitchStateToIdle()
    {
        SwitchState(IdleState);
    }
}
