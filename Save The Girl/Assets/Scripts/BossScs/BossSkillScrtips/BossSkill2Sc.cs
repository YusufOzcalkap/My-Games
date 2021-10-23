using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill2Sc : MonoBehaviour
{
    public bool isNova;
    public float NovaSpeed;
    public GameObject Projectiles;


    public Transform novaSpawnPos;
    public GameObject Nova;
    void Start()
    {
        
    }


    void Update()
    {
        if(isNova)
        {
            transform.Translate(Vector3.up * NovaSpeed * Time.deltaTime);

            if(transform.position.y >= 12)
            {
                Instantiate(Projectiles, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }

        }
    }

    public void SpawnNova()
    {
        Instantiate(Nova, novaSpawnPos.position, novaSpawnPos.rotation);
    }

}
