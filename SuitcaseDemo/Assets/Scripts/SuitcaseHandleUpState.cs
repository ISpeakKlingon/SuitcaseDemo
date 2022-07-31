using UnityEngine;

public class SuitcaseHandleUpState : SuitcaseBaseState
{

    public override void EnterState(SuitcaseStateManager suitcase)
    {
        Debug.Log("Hello from the Handle Up State");
        GameManager.Instance.UpdateGameState(GameManager.GameState.HandleUp);

        // animate handle up
        SuitcaseHandleAnimator = suitcase.GetComponent<Animator>();
        SuitcaseHandleAnimator.SetTrigger("handleUp");

        // move camera to new focus
        CameraController = suitcase.GetComponentInParent<CameraController>();
        HandlePos = GameManager.Instance.Handle.transform.position;
        HandlePointOfFocus = GameManager.Instance.HandlePointOfFocus;
        //CameraController.MoveCamera(CameraDelayTime, HandlePos, HandlePointOfFocus);
        CameraController.DebugTest("Hi there CameraController. This is the SuitcaseHandleUpState script pingin you!"); //this line (and one above) are causing error.
    }

    public override void UpdateState(SuitcaseStateManager suitcase)
    {

    }
}
