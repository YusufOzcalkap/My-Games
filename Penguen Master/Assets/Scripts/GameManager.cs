using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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
        if (other.CompareTag("Artý"))
        {
            Penguins.instance.penguinCount += other.GetComponent<Wall>().number;
        }

        if (other.CompareTag("Carpma"))
        {
            Penguins.instance.penguinCount *= other.GetComponent<WallCarpma>().number;
        }
    }
}
