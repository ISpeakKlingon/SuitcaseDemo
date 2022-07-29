using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleController : MonoBehaviour
{
    public GameObject suitcaseHandle;
    public GameObject mainCamera;
    public GameObject handleViewObj;
    public GameObject startingViewObj;
    public GameObject suitcaseBody;
    public GameObject handleButton;
    public GameObject handlePointOfFocus;
    public GameObject bodyPointOfFocus;

    private Animator _suitcaseHandleAnimator;

    const string HANDLEUP_ANIM = "handleUp";
    const string HANDLEDOWN_ANIM = "handleDown";

    const string HANDLE_ANIM = "handle";

    private bool _handleActive;

    private CameraController _cameraController;

    private float delayTime;
    private Vector3 _handleViewPos;
    private Vector3 _startingViewPos;

    //material info
    private Material _material;

    private int i;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        _suitcaseHandleAnimator = suitcaseHandle.GetComponent<Animator>();
        _cameraController = mainCamera.GetComponent<CameraController>();
        _handleViewPos = handleViewObj.transform.position;
        _startingViewPos = startingViewObj.transform.position;

        //get button material
        _material = GetComponent<Renderer>().material;

        //set button alpha to 0
        //Color color = _material.color;
        //color.a = 0f;
        //_material.color = color;


        //fade in button alpha
        //StartCoroutine(FadeAlphaToFull(_material, 1f));

        //fade out button alpha
        //StartCoroutine(FadeAlphaToZero(_material, 2f));

        //target = handleButton.transform;
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse click registered.");

        if (!_handleActive)
        {
            Debug.Log("_handleActive bool is false, therefore...");

            target = handlePointOfFocus.transform;

            //send move event to camera
            _cameraController.MoveCamera(delayTime, _handleViewPos, target);

            _suitcaseHandleAnimator.SetTrigger(HANDLEUP_ANIM);

            Debug.Log("activated trigger for handle up anim and...");

            _handleActive = true;
            Debug.Log("set handleActive bool to true.");
        }
        else
        {
            target = bodyPointOfFocus.transform;
            _cameraController.MoveCamera(delayTime, _startingViewPos, target);
            _suitcaseHandleAnimator.SetTrigger(HANDLEDOWN_ANIM);
            _handleActive = false;
            Debug.Log("set handleActive bool to false.");
        }

    }

    private void FadeInButton()
    {
        /*i = 0;
        Color color = _material.color;
        color.a = 0f;
        _material.color = color;

        while (i < 255)
        {
            color.a = i + 1;
            _material.color = color;
            i += 1;
        }*/
    }

    private void FadeButton(float desiredAlpha)
    {
        Color color = _material.color;

        float currentAlpha = color.a;

        currentAlpha = Mathf.MoveTowards(currentAlpha, desiredAlpha, 2.0f * Time.deltaTime);
    }

    IEnumerator FadeAlphaToZero(Material material, float duration)
    {
        Color startColor = material.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0);
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            material.color = Color.Lerp(startColor, endColor, time / duration);
            yield return null;
        }
    }

    IEnumerator FadeAlphaToFull(Material material, float duration)
    {
        Color startColor = material.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 255);
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            material.color = Color.Lerp(startColor, endColor, time / duration);
            yield return null;
        }
    }
}
