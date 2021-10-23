using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    public static DestroyController instance;

    public bool Boom;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Boom = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            this.Boom = false;
        }
    }
}
