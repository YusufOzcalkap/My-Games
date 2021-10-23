using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public Transform[] waypoints;
    public int Speed;

    int waypointindex;
    float dist;

    Animator anim;

    public EnemyattackDetect ead;

    //public GameObject SuperSonicImpact;
    //public GameObject NormalImpact;

   

    ////Auidos
    //public AudioClip PunchFX;
    //public AudioClip SPunchFX;
    //AudioSource aus;

    private void Start()
    {
        anim = GetComponent<Animator>();
        waypointindex = 0;
        transform.LookAt(waypoints[waypointindex].position);
       
    }

    private void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointindex].position);
        if (dist < 2f)
        {
            IncreseIndex();
        }
        Patrol();
    }

    public void Patrol()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        anim.SetBool("Run", true);
    }

    void IncreseIndex()
    {
        waypointindex = Random.Range(0, waypoints.Length);
        if(waypointindex >= waypoints.Length)
        {
            waypointindex = 0;
        }
        transform.LookAt(waypoints[waypointindex].position);

    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "NormalPunch")
    //    {
    //        anim.SetTrigger("GetHit");
    //        Instantiate(NormalImpact, transform.position + new Vector3(0, 1, 0), transform.rotation);
    //        aus.clip = PunchFX;
    //        aus.Play();
    //        ead.punchCollider.enabled = false;
    //        ead.SuperpunchCollider.enabled = false;
    //    }
    //    if (other.gameObject.tag == "SuperPunch")
    //    {
    //        anim.enabled = false;
    //        GetComponent<Collider>().enabled = false;
            
    //        Instantiate(SuperSonicImpact, transform.position + new Vector3(0, 1, 0), transform.rotation);
    //        aus.clip = SPunchFX;
    //        aus.Play();
    //        ead.punchCollider.enabled = false;
    //        ead.SuperpunchCollider.enabled = false;
    //    }
    //    if (other.gameObject.tag == "PowerUp")
    //    {
    //        ead.SuperSonicCounter += 50;
    //        Destroy(other.gameObject);
    //    }
    //}

    public void AttackCollsOpen()
    {
        if(ead.SuperSonicCounter >= 100)
        {
            ead.SuperpunchCollider.enabled = true;
            //ead.SuperSonicCounter -= 100;
        }
        else
        {
            ead.punchCollider.enabled = true;
        }

    }
    public void AttackCollsClose()
    {
        if (ead.SuperSonicCounter >= 100)
        {
            ead.SuperpunchCollider.enabled = false;
            ead.SuperSonicCounter -= 100;
        }
        else
        {
            ead.punchCollider.enabled = false;
            ead.SuperSonicCounter -= 20;
        }

    }
}
