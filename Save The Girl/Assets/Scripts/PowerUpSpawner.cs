using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject PowerUp;

    public float timer;
    public float getSpawn;

    public Transform[] Spawners;

    public int spawnerindex;

    void Start()
    {
        spawnerindex = Random.Range(0, Spawners.Length);
    }


    void Update()
    {
        timer += 1 * Time.deltaTime;
        if(timer >= getSpawn)
        {
            spawnerindex = Random.Range(0, Spawners.Length);
            Instantiate(PowerUp, Spawners[spawnerindex].position + new Vector3(0,1,0), Spawners[spawnerindex].rotation);
            timer = 0;
        }
    }
}
