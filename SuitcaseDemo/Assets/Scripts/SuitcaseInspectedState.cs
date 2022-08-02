using UnityEngine;

public class SuitcaseInspectedState : SuitcaseBaseState
{
    public override void EnterState(SuitcaseStateManager suitcase)
    {
        Debug.Log("Hello from the Inspected State");
        GameManager.Instance.UpdateGameState(GameManager.GameState.Inspected);

        // change UI text
        GameManager.Instance.CurrentHeader = GameManager.Instance.LockHeader;
        GameManager.Instance.CurrentDescription = GameManager.Instance.LockDescription;

        // turn off box collider on SuitcaseParent to disable spinning
        SpinnerCollider = suitcase.GetComponent<BoxCollider>();
        SpinnerCollider.enabled = false;

        // move camera to new focus
        CameraController = GameManager.Instance.MainCamera.GetComponent<CameraController>();
        EdgePos = GameManager.Instance.Edge.transform.position;
        EdgePointOfFocus = GameManager.Instance.EdgePointOfFocus;
        CameraController.MoveCamera(CameraDelayTime, EdgePos, EdgePointOfFocus);
    }

    public override void UpdateState(SuitcaseStateManager suitcase)
    {

    }
}
