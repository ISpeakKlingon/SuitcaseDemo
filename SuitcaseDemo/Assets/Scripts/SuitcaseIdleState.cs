using UnityEngine;

public class SuitcaseIdleState : SuitcaseBaseState
{
    public override void EnterState(SuitcaseStateManager suitcase)
    {
        Debug.Log("Hello from the Idle State");

        // tell Game Manager to go into Idle state
        GameManager.Instance.UpdateGameState(GameManager.GameState.Idle);

        // if handle is up, move it down
        if (GameManager.Instance.HandleUp == true)
        {
            SuitcaseHandleAnimator = suitcase.GetComponent<Animator>();
            SuitcaseHandleAnimator.SetTrigger("handleDown");
            GameManager.Instance.HandleUp = false;
        }
        
        // move camera to new focus
        CameraController = GameManager.Instance.MainCamera.GetComponent<CameraController>();
        BodyPos = GameManager.Instance.Body.transform.position;
        BodyPointOfFocus = GameManager.Instance.BodyPointOfFocus;

        if (GameManager.Instance.SuitcaseOpen)
        {
            CameraController.MoveCamera(CameraDelayTime, BodyPos, BodyPointOfFocus);
        }
        else
        CameraController.MoveCamera(CameraDelayTime, BodyPos, BodyPointOfFocus);

        // if suitcase is open, close it
        if (GameManager.Instance.SuitcaseOpen == true)
        {
            SuitcaseHandleAnimator = suitcase.GetComponent<Animator>();
            SuitcaseHandleAnimator.SetTrigger("close");
            GameManager.Instance.SuitcaseOpen = false;
        }

        // turn on box collider on SuitcaseParent to enable spinning
        SpinnerCollider = suitcase.GetComponent<BoxCollider>();
        SpinnerCollider.enabled = true;
    }

    public override void UpdateState(SuitcaseStateManager suitcase)
    {

    }
}
