using UnityEngine;

public class SuitcaseOpenState : SuitcaseBaseState
{
    public override void EnterState(SuitcaseStateManager suitcase)
    {
        Debug.Log("Hello from the Open State");

        // tell Game Manager to go into Idle state
        GameManager.Instance.UpdateGameState(GameManager.GameState.Open);

        // move camera to new focus
        CameraController = GameManager.Instance.MainCamera.GetComponent<CameraController>();
        InteriorPos = GameManager.Instance.Interior.transform.position;
        InteriorPointOfFocus = GameManager.Instance.InteriorPointOfFocus;
        CameraController.MoveCamera(CameraDelayTime, InteriorPos, InteriorPointOfFocus);

    }

    public override void UpdateState(SuitcaseStateManager suitcase)
    {

    }
}
