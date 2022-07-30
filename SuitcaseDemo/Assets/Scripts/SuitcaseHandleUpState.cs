using UnityEngine;

public class SuitcaseHandleUpState : SuitcaseBaseState
{

    public override void EnterState(SuitcaseStateManager suitcase)
    {
        Debug.Log("Hello from the Handle Up State");
        GameManager.Instance.UpdateGameState(GameManager.GameState.HandleUp);

        // animate handle up
        //SuitcaseHandleAnimator = suitcaseHandle.GetComponent<Animator>();
        SuitcaseHandleAnimator = suitcase.GetComponent<Animator>();
        SuitcaseHandleAnimator.SetTrigger("handleUp");
    }

    public override void UpdateState(SuitcaseStateManager suitcase)
    {

    }
}
