using UnityEngine;

public class SuitcaseIdleState : SuitcaseBaseState
{
    public override void EnterState(SuitcaseStateManager suitcase)
    {
        Debug.Log("Hello from the Idle State");

        // tell Game Manager to go into Idle state
        GameManager.Instance.UpdateGameState(GameManager.GameState.Idle);

        //suitcase idle event
    }

    public override void UpdateState(SuitcaseStateManager suitcase)
    {

    }
}
