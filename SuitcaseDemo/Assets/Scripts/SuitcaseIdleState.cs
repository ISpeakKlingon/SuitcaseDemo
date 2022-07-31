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
        CameraController.MoveCamera(CameraDelayTime, BodyPos, BodyPointOfFocus);
    }

    public override void UpdateState(SuitcaseStateManager suitcase)
    {

    }
}
