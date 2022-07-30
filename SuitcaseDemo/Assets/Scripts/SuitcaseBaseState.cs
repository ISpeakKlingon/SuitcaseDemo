using UnityEngine;

public abstract class SuitcaseBaseState
{
    public GameObject suitcaseHandle;

    public Animator SuitcaseHandleAnimator;

    public abstract void EnterState(SuitcaseStateManager suitcase);
    public abstract void UpdateState(SuitcaseStateManager suitcase);
}
