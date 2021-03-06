using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Top;
    public GameObject karakterim;
    float spawnZaman;
    float kafamaZaman;

    bool AtesHazır;
    bool kafamaHazır;

    public AudioSource kafamaSes;


    // Start is called before the first frame update
    void Start()
    {
        AtesHazır = false;
        kafamaHazır = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (AtesHazır == true)
        {
            spawnZaman += Time.deltaTime;
            if (spawnZaman > 3)
            {
                float Randomum = Random.Range(70, 88);
                Vector3 yon = new Vector3(Randomum, transform.position.y, transform.position.z);
                Instantiate(Top, yon, Quaternion.identity);
                kafamaSes.Play();
                spawnZaman = 0;
            }
        }

        if (kafamaHazır == true)
        {
            kafamaZaman += Time.deltaTime;
            if (kafamaZaman > 4)
            {
                Vector3 yon = new Vector3(karakterim.transform.position.x, transform.position.y, transform.position.z);
                Instantiate(Top, yon, Quaternion.identity);
                kafamaSes.Play();

                kafamaZaman = 0;
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.gameObject.CompareTag("Player"))
        {
            kafamaHazır = true;
            AtesHazır = true;
           

        }
    }


}
