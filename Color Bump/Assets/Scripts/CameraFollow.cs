using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraSpeed = 6;
    public Vector3 camVel;
    void Start()
    {
        
    }

    void Update()
    {
        if (FindObjectOfType<PlayerController>().canMove)
        {
            transform.position += Vector3.forward * cameraSpeed;
        }
        camVel = Vector3.forward * cameraSpeed;
    }
}
