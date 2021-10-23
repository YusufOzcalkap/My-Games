using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform PlayerTransform;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public bool LookAtPlayer = false;

    public  Animator anim;
    // Use this for initialization
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
        anim = GetComponent<Animator>();
        instance = this;
    }
    // LateUpdate is called after Update
    void LateUpdate()
    {

        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
    }

    public void SetCamera()
    {
        StressReceiver.instance.InduceStress(0.5f);
    }


}
