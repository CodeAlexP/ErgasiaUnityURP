using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap: MonoBehaviour
{

   
   
    private Transform cameraTransform;
    private Quaternion initialRotation;

void Start()
{
    // Get the transform of the main camera and the initial rotation of the minimap.
    cameraTransform = Camera.main.transform;
    initialRotation = transform.rotation;
}

void Update()
{
    // Get the y-axis rotation of the camera and create a new quaternion rotation to apply to the minimap.
    float angle = cameraTransform.eulerAngles.y;
    Quaternion rotation = Quaternion.Euler(0, 0, -angle);

    // Set the rotation of the minimap to the initial rotation plus the new camera rotation.
    transform.rotation = initialRotation * rotation;
}
}



