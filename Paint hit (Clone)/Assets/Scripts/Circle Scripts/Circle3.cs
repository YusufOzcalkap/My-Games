using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle3 : MonoBehaviour
{
    void Start()
    {
        iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
       {
         "y",
         0,
         "easetype",
         iTween.EaseType.easeInCirc,
         "time",
         0.6,
         "OnComplete",
         "rotatecircle"
       }));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * Time.deltaTime * (Ballhandler.rotationSpeed + 20));
    }
}
