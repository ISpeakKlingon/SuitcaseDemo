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

        // if suitcase is open, close it
        if(GameManager.Instance.SuitcaseOpen == true)
        {
            SuitcaseHandleAnimator = suitcase.GetComponent<Animator>();
            SuitcaseHandleAnimator.SetTrigger("close");
            GameManager.Instance.SuitcaseOpen = false;
        }

        // move camera to new focus
        CameraController = GameManager.Instance.MainCamera.GetComponent<CameraController>();
        BodyPos = GameManager.Instance.Body.transform.position;
        BodyPointOfFocus = GameManager.Instance.BodyPointOfFocus;
        CameraController.MoveCamera(CameraDelayTime, BodyPos, BodyPointOfFocus);

        // turn off box collider on SuitcaseParent to disable spinning
        SpinnerCollider = suitcase.GetComponent<BoxCollider>();
        SpinnerCollider.enabled = true;

        // spin suitcase back to zero
        /*float _currentRot = suitcase.transform.localRotation.y;
        
        if (_currentRot != 0f)
        {
            Debug.Log("SuitcaseIdleState thinks that current rotation is NOT 0.");
            SuitcaseSpinner = suitcase.GetComponent<SuitcaseSpinner>();
            SuitcaseSpinner.ResetSpin();
        }*/
    }

    public override void UpdateState(SuitcaseStateManager suitcase)
    {

    }
}
