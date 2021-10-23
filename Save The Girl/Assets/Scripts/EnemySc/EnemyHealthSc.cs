using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSc : MonoBehaviour
{
    public float Health;

    Animator anim;

    public EnemyattackDetect ead;

    public GameObject SuperSonicImpact;
    public GameObject NormalImpact;

    GameManager gm;

    //Uý Parts
    public Slider HealthBar;

    //Auidos
    public AudioClip PunchFX;
    public AudioClip SPunchFX;
    AudioSource aus;
    void Start()
    {
        anim = GetComponent<Animator>();
        aus = GetComponent<AudioSource>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
       

    }


    void Update()
    {
        HealthBar.gameObject.transform.LookAt(Camera.main.transform.position);
        HealthBar.value = Health;
     


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NormalPunch")
        {
            anim.SetTrigger("GetHit");
            Instantiate(NormalImpact, transform.position + new Vector3(0, 1, 0), transform.rotation);
            aus.clip = PunchFX;
            aus.Play();
            ead.punchCollider.enabled = false;
            ead.SuperpunchCollider.enabled = false;
            Health -= 20;

            if (Health<= 0)
            {
                gm.GetComponent<TotalHealthbarSc>().EnemyCounter += 1;
                anim.enabled = false;
                GetComponent<Collider>().enabled = false;
                Instantiate(SuperSonicImpact, transform.position + new Vector3(0, 1, 0), transform.rotation);
                aus.clip = SPunchFX;
                aus.Play();
                ead.punchCollider.enabled = false;
                ead.SuperpunchCollider.enabled = false;

                HealthBar.gameObject.SetActive(false);
                Destroy(this.gameObject, 2f);
            }
        }
        if (other.gameObject.tag == "SuperPunch")
        {
            Health = 0;

            anim.enabled = false;
            GetComponent<Collider>().enabled = false;
            gm.GetComponent<TotalHealthbarSc>().EnemyCounter += 1;
            Instantiate(SuperSonicImpact, transform.position + new Vector3(0, 1, 0), transform.rotation);
            aus.clip = SPunchFX;
            aus.Play();
            ead.punchCollider.enabled = false;
            ead.SuperpunchCollider.enabled = false;
            Destroy(this.gameObject, 5f);
        }
        if (other.gameObject.tag == "PowerUp")
        {
            ead.SuperSonicCounter += 50;
            Destroy(other.gameObject);
        }
    }
}
