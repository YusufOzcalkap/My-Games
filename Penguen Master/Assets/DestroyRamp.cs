using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DestroyRamp : MonoBehaviour
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
            other.GetComponent<NavMeshAgent>().enabled = false;
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, 1f, 0);
            StartCoroutine(setFall(other));
        }
    }

    IEnumerator setFall(Collider c)
    {
        yield return new WaitForSeconds(1f);

        Destroy(c.gameObject);
        Penguins.instance.penguinCount--;
    }
}
