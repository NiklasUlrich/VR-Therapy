using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FaceCamera : MonoBehaviour
{
    private Transform cameraTransform;

    private void Start()
    {
        // Get the main camera's transform
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // Calculate the look rotation to face the camera
        Vector3 lookDirection = cameraTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookDirection);

        // Apply the rotation to the object
        transform.rotation = rotation;
        transform.Rotate(0, 180, 0);
    }
}
