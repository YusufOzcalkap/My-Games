using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Transform home;
    NavMeshAgent agent;

    private Animator anim;
    private Rigidbody rg;

    public int a;
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
        anim.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<NavMeshAgent>().enabled = true;
        agent.SetDestination(home.position);

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            a++;    
        }
    }

    
}
