using UnityEngine;

public abstract class SuitcaseBaseState
{
    public GameObject suitcaseHandle;

    public Animator SuitcaseHandleAnimator;

    public CameraController CameraController;
    
    [Header("Camera Positions")]
    public GameObject Body;
    public GameObject Handle;
    public GameObject Interior;
    public GameObject Edge;

    [Header("Camera Position Vectors")]
    public Vector3 BodyPos;
    public Vector3 HandlePos;
    public Vector3 InteriorPos;
    public Vector3 EdgePos;

    [Header("Points of Focus")]
    public Transform BodyPointOfFocus;
    public Transform HandlePointOfFocus;
    public Transform InteriorPointOfFocus;
    public Transform EdgePointOfFocus;

    public float CameraDelayTime;

    public abstract void EnterState(SuitcaseStateManager suitcase);
    public abstract void UpdateState(SuitcaseStateManager suitcase);
}
