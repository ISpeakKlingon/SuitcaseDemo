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

    private SphereCollider _collider;

    private ButtonFader _buttonFader;

    // Start is called before the first frame update
    void Start()
    {
        _idleState = SuitcaseStateManager.IdleState;
        _inspectedState = SuitcaseStateManager.InspectedState;
        _openState = SuitcaseStateManager.OpenState;
        _handleUpState = SuitcaseStateManager.HandleUpState;

        _collider = GetComponent<SphereCollider>();

        _buttonFader = GetComponent<ButtonFader>();
    }

    private void GetLinkedState(StateToActivate newState)
    {
        StateToLink = newState;

        switch (newState)
        {
            case StateToActivate.IdleState:
                Debug.Log("ButtonController activated sphere collider.");
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
        // turn off collider
        //DeactivateButton(); //switching this to ButtonFader script

        GetLinkedState(StateToLink);
    }

    private void OnMouseEnter()
    {
        // turn button alpha up
        _buttonFader.MaxAlpha();
    }

    private void OnMouseExit()
    {
        // turn button alpha down
        _buttonFader.ResetAlpha();
    }

    public void DeactivateButton()
    {
        _collider.enabled = false;
    }

    public void ActivateButton()
    {
        _collider.enabled = true;
    }

    public enum StateToActivate
    {
        IdleState,
        InspectedState,
        OpenState,
        HandleUpState
    }
}
