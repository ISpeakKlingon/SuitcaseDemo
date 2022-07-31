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
        GameManager.Instance.HandleUp = true;

        // move camera to new focus
        CameraController = GameManager.Instance.MainCamera.GetComponent<CameraController>();
        HandlePos = GameManager.Instance.Handle.transform.position;
        HandlePointOfFocus = GameManager.Instance.HandlePointOfFocus;
        CameraController.MoveCamera(CameraDelayTime, HandlePos, HandlePointOfFocus);
    }

    public override void UpdateState(SuitcaseStateManager suitcase)
    {

    }
}
