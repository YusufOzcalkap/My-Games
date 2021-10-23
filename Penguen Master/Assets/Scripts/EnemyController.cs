using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    public Transform home;
    NavMeshAgent agent;

    private Animator anim;
    private Rigidbody rg;

    public int a;
    private bool b = true; 
    void Awake()
    {
        this.GetComponent<NavMeshAgent>().enabled = false;
        instance = this;
        a = 0;
    }

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        agent = this.GetComponent<NavMeshAgent>();
        this.GetComponent<NavMeshAgent>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<NavMeshAgent>().enabled = true;
        agent.SetDestination(home.position);

        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        GetComponent<BoxCollider>().isTrigger = true;
    //        if (b)
    //        {
    //            Penguins.instance.penguinCount -= collision.gameObject.GetComponent<PlayerController>().a;
    //            Destroy(collision.gameObject);
    //            Destroy(gameObject);
    //            b = false;
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider>().isTrigger = true;
            if (b)
            {
                Penguins.instance.penguinCount--;
                Destroy(other.gameObject);
                Destroy(gameObject);
                b = false;
            }
        }
    }



    IEnumerator SetDead()
    {
        yield return new WaitForSeconds(0.1f);

        Penguins.instance.penguinCount--;
    }
}
