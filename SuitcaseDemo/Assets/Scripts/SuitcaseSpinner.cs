using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitcaseSpinner : MonoBehaviour
{
    private float _rotationSpeed = 1f;
    private float _delayTime;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameManager.GameState state)
    {
        ResetSpin();
    }

    private void OnMouseDrag()
    {
       float XaxisRotation = Input.GetAxis("Mouse X") * _rotationSpeed;
       //float YaxisRotation = Input.GetAxis("Mouse Y") * _rotationSpeed;

       transform.Rotate(Vector3.down, XaxisRotation, Space.World);
       //transform.Rotate(Vector3.right, YaxisRotation, Space.World);
    }

    public void ResetSpin()
    {
        Debug.Log("SuitcaseSpinner has called ResetSpin().");
        StartCoroutine(WaitAndSpinToZero(_delayTime));
    }

    IEnumerator WaitAndSpinToZero(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        float moveSpeed = 100f;
        Quaternion endingAngle = Quaternion.Euler(new Vector3(0, 0, 0));
        while(Vector3.Distance(transform.rotation.eulerAngles,endingAngle.eulerAngles) > 0.01f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, endingAngle, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.rotation = endingAngle;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }

}
