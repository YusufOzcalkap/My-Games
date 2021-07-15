using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y <= -9)
        {
            Destroy(gameObject);
        }
    }
}
