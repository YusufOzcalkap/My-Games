using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle1 : MonoBehaviour
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
         0.2,
         "OnComplete",
         "rotatecircle"
        }));
        
    }

    void rotatecircle()
    {
        
    }


    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * Ballhandler.rotationSpeed);
        PlayerPrefs.SetInt("C_Level", 1);
    }
}
