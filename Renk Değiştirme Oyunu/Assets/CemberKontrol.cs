using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemberKontrol : MonoBehaviour
{
    public float DonmeH�z� ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, DonmeH�z�*Time.deltaTime);

    }
}
