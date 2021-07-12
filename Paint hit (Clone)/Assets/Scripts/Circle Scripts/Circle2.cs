using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle2 : MonoBehaviour
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


    void rotatecircle()
    {
        iTween.RotateBy(base.gameObject, iTween.Hash(new object[]
        {
            "y",
            0.8f,
            "time",
            Ballhandler.rotationTime,
            "easeType",
            iTween.EaseType.easeInOutQuad,
            "loopType",
            iTween.LoopType.pingPong,
            "delay",
            0.4
        }));
    }
}
