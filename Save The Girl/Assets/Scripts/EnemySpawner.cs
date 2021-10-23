using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    void Start()
    {
        Instantiate(EnemyPrefab, transform.position, transform.rotation);
    }


    void Update()
    {
        
    }
}
