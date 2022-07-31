using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float delayTime;
    private Vector3 _posA;
    private Vector3 _posB;

    private Vector3 _startingPos;
    private Vector3 _handlePos;

    public GameObject startingView;
    public GameObject handleView;
    
    public Transform suitcaseBody;
    public Transform suitcaseHandle;

    private Transform target;
    private Vector3 _receivedPos;

    // Start is called before the first frame update
    void Start()
    {
        _startingPos = startingView.transform.position;
        _handlePos = handleView.transform.position;

        //define first target
        target = suitcaseBody;

        //StartCoroutine(WaitAndMove(delayTime, _startingPos, target));
    }

    IEnumerator WaitAndMove(float delayTime, Vector3 newPos, Transform target)
    {
        _posA = transform.position;
        _posB = newPos;

        yield return new WaitForSeconds(delayTime);
        float startTime = Time.time;
        while (Time.time - startTime <= 1)
        {
            transform.position = Vector3.Lerp(_posA, _posB, Time.time - startTime);

            //get rotatation info
            Vector3 relativePos = (target.position + new Vector3(0, 0, 0)) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            Quaternion current = transform.localRotation;

            //rotate camera
            transform.localRotation = Quaternion.Slerp(current, rotation, Time.time - startTime);

            yield return 1;
        }
    }

    public void MoveCamera(float delayTime, Vector3 newPos, Transform target)
    {
        StartCoroutine(WaitAndMove(delayTime, newPos, target));
    }

    public void DebugTest(string message)
    {
        Debug.Log(message);
    }

}
