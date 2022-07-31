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
            Debug.Log("SuitcaseIdleState thinks handle is up, therefore...");
            SuitcaseHandleAnimator = suitcase.GetComponent<Animator>();
            Debug.Log("... it is getting the animator for the suitcase...");
            SuitcaseHandleAnimator.SetTrigger("handleDown");
            Debug.Log("... triggering handleDown ...");

            GameManager.Instance.HandleUp = false;

            Debug.Log("... and setting the HandleUp bool to false...");

        }

        //suitcase idle event
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
