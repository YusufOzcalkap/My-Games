using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSecond : MonoBehaviour
{
    public static EnemySpawnSecond instance;

    public GameObject penguin;
    public GameObject player;
    public GameObject pengu;
    public Transform home;
    public Transform homePlayer;

    public int penguinEnemy;

    private float plus;
    public bool dur = false;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        for (int i = 0; i < penguinEnemy; i++)
        {
            if (penguinEnemy == transform.childCount)
            {
                break;
            }
            GameObject enemy = Instantiate(penguin);
            enemy.transform.GetComponent<EnemyController>().home = home;
            enemy.transform.parent = this.transform;
            plus += 0.001f;
            enemy.transform.position = new Vector3(transform.position.x + plus, transform.position.y, transform.position.z);
        }
    }

    void Update()
    {
        if (transform.childCount == 0)
        {
            dur = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dur = true;

            print("ikinci dusman");
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<EnemyController>().home = homePlayer;
            }
        }
    }
}
