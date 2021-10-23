using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RampaControl : MonoBehaviour
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
        if (other.CompareTag("Player"))
        {
            print("uc");
            other.GetComponent<NavMeshAgent>().enabled = false;
            other.GetComponent<Rigidbody>().AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            StartCoroutine(jumpSet(other));
        }
    }

    IEnumerator jumpSet(Collider c)
    {
        yield return new WaitForSeconds(2.2f);
        c.GetComponent<NavMeshAgent>().enabled = true;
    }
}
