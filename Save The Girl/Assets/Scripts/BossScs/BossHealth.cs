using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float Health;
    Animator anim;

    public GameObject NormalImpact;
    public GameObject SuperSonicImpact;


    //Auidos
    public AudioClip PunchFX;
    public AudioClip SPunchFX;
    AudioSource aus;

    GameManager gm;
    void Start()
    {
        anim = GetComponent<Animator>();
        aus = GetComponent<AudioSource>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        if(Health <= 0)
        {
            gm.isRestart = true;
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NormalPunch")
        {
            anim.SetTrigger("GetHit");
            Instantiate(NormalImpact, transform.position + new Vector3(0, 1, 0), transform.rotation);
            aus.clip = PunchFX;
            aus.Play();
            Health -= 20;
            if (Health <= 0)
            {

                Instantiate(SuperSonicImpact, transform.position + new Vector3(0, 1, 0), transform.rotation);
                aus.clip = SPunchFX;
                aus.Play();
            }
        }
        if (other.gameObject.tag == "SuperPunch")
        {
            Health -= 100;
            Instantiate(SuperSonicImpact, transform.position + new Vector3(0, 1, 0), transform.rotation);
            aus.clip = SPunchFX;
            aus.Play();

        }
    }
}
