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
        cameraTransform = Camera.main.transform;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        float angle = cameraTransform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, 0, -angle);
        transform.rotation = initialRotation * rotation;
    }
}



