using UnityEngine;

public class SuitcaseHandleUpState : SuitcaseBaseState
{

    public override void EnterState(SuitcaseStateManager suitcase)
    {
        Debug.Log("Hello from the Handle Up State");
        GameManager.Instance.UpdateGameState(GameManager.GameState.HandleUp);

        // change UI text
        GameManager.Instance.CurrentHeader = GameManager.Instance.HandleHeader;
        GameManager.Instance.CurrentDescription = GameManager.Instance.HandleDescription;

        // turn off box collider on SuitcaseParent to disable spinning
        SpinnerCollider = suitcase.GetComponent<BoxCollider>();
        SpinnerCollider.enabled = false;

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
