using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopuTakipEt : MonoBehaviour
{
    public Transform TopunPozisyonu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TopunPozisyonu.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, TopunPozisyonu.position.y, transform.position.z);
        }
    }
}
