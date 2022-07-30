using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScaler : MonoBehaviour
{
    public GameObject mainCamera;
    private Vector3 _initialScale;
    private float _initialDistance;

    private void Start()
    {
        _initialScale = transform.localScale;
        _initialDistance = Vector3.Distance(mainCamera.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // calculate distance between button and camera
        float distance = Vector3.Distance(mainCamera.transform.position, transform.position);
        //Debug.Log("Distance between camera and button is " + distance);

        // calculate difference between this new distance and initial distance
        float difference = distance - _initialDistance;

        float scaleMultiplier = (difference + 1);

        //scale button accordingly
        transform.localScale = new Vector3(_initialScale.x * scaleMultiplier, _initialScale.y * scaleMultiplier, _initialScale.z * scaleMultiplier);
    }
}
