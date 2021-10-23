using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rigidbody[] rg = transform.GetComponentsInChildren<Rigidbody>();
        //foreach (Rigidbody childcol in rg)
        //{
        //    childcol.constraints = RigidbodyConstraints.FreezePosition;
        //}
    }

    public void StopPos()
    {
        Rigidbody[] rg = transform.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody childcol in rg)
        {
            childcol.constraints = RigidbodyConstraints.FreezePosition;
        }
    }
}
