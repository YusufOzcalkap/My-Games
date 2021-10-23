using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Down"))
        {
            print("Vurdu");
            transform.parent.transform.parent.GetComponent<MoneyController>().direction = 1;
        }
        if (other.transform.CompareTag("Up"))
        {
            transform.parent.transform.parent.GetComponent<MoneyController>().direction = -1;
        }
    }
}
