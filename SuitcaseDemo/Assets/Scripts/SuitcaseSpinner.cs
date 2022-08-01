using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitcaseSpinner : MonoBehaviour
{
    private float _rotationSpeed = 1f;

    private void OnMouseDrag()
    {
       float XaxisRotation = Input.GetAxis("Mouse X") * _rotationSpeed;
       //float YaxisRotation = Input.GetAxis("Mouse Y") * _rotationSpeed;

       transform.Rotate(Vector3.down, XaxisRotation, Space.World);
       //transform.Rotate(Vector3.right, YaxisRotation, Space.World);
    }
}
