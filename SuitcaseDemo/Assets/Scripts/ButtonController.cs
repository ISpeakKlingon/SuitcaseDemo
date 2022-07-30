using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public SuitcaseStateManager SuitcaseStateManager;

    private SuitcaseIdleState _idleState;
    private SuitcaseInspectedState _inspectedState;
    private SuitcaseOpenState _openState;
    private SuitcaseHandleUpState _handleUpState;

    public StateToActivate StateToLink;

    // Start is called before the first frame update
    void Start()
    {
        _idleState = SuitcaseStateManager.IdleState;
        _inspectedState = SuitcaseStateManager.InspectedState;
        _openState = SuitcaseStateManager.OpenState;
        _handleUpState = SuitcaseStateManager.HandleUpState;
    }

    private void GetLinkedState(StateToActivate newState)
    {
        StateToLink = newState;

        switch (newState)
        {
            case StateToActivate.IdleState:
                SuitcaseStateManager.SwitchState(_idleState);
                Debug.Log("button thinks the linked state is IdleState.");
                break;
            case StateToActivate.InspectedState:
                SuitcaseStateManager.SwitchState(_inspectedState);
                Debug.Log("button thinks the linked state is InspectedState.");
                break;
            case StateToActivate.OpenState:
                SuitcaseStateManager.SwitchState(_openState);
                Debug.Log("button thinks the linked state is OpenState.");
                break;
            case StateToActivate.HandleUpState:
                SuitcaseStateManager.SwitchState(_handleUpState);
                Debug.Log("button thinks the linked state is HandleUpState.");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    private void OnMouseDown()
    {
        GetLinkedState(StateToLink);
    }

    public enum StateToActivate
    {
        IdleState,
        InspectedState,
        OpenState,
        HandleUpState
    }
}
