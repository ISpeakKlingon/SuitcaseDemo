using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipperController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject openViewObj;
    public GameObject startingViewObj;
    public GameObject suitcaseBody;
    public GameObject bodyPointOfFocus;
    public GameObject interiorPointOfFocus;

    private Animator _suitcaseBodyAnimator;

    const string OPEN_ANIM = "open";
    const string CLOSE_ANIM = "close";

    private bool _suitcaseOpen;

    private CameraController _cameraController;

    private float delayTime;
    private Vector3 _openViewPos;
    private Vector3 _startingViewPos;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        _suitcaseBodyAnimator = suitcaseBody.GetComponent<Animator>();
        _cameraController = mainCamera.GetComponent<CameraController>();
        _openViewPos = openViewObj.transform.position;
        _startingViewPos = startingViewObj.transform.position;
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse click registered.");

        if (!_suitcaseOpen)
        {
            Debug.Log("_suitcaseOpen bool is false, therefore...");

            target = interiorPointOfFocus.transform;

            //send move event to camera
            _cameraController.MoveCamera(delayTime, _openViewPos, target);

            _suitcaseBodyAnimator.SetTrigger(OPEN_ANIM);

            Debug.Log("activated trigger for suitcase open anim and...");

            _suitcaseOpen = true;
            Debug.Log("set _suitcaseOpen bool to true.");
        }
        else
        {
            target = bodyPointOfFocus.transform;
            _cameraController.MoveCamera(delayTime, _startingViewPos, target);
            _suitcaseBodyAnimator.SetTrigger(CLOSE_ANIM);
            _suitcaseOpen = false;
            Debug.Log("set _suitcaseOpen bool to false.");
        }

    }
}
