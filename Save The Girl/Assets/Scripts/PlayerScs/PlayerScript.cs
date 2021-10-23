using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameAnalyticsSDK;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;
    public Animator anim;

    [HideInInspector]
    public bool jumpAt = false;

    public float SuperSonicCount;
    public Slider SuperSonicSlider;

    public Collider NormalPunch;
    public Collider SuperPunch;

    public ParticleSystem lightning;
    public bool isSuper;

    public GameObject SuperSonicImpact;
    public GameObject NormalPunchImpact;

    //Auidos
    public AudioClip PunchFX;
    public AudioClip SPunchFX;
    AudioSource aus;

    //HealthSystem
    public float Health;
    public Slider HealthBar;

    //others
    GameManager gm;

    private void Awake()
    {
        GameAnalytics.Initialize();
    }
    void Start()
    {
        instance = this;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        SuperSonicSlider.maxValue = 100;
        aus = GetComponent<AudioSource>();
    }


    void Update()
    {
        

        SuperSonicSlider.value = SuperSonicCount;
        if (SuperSonicCount < 0)
        {
            SuperSonicCount = 0;
        }

        HealtSystem();
    }

    public void LightingCheck()
    {
        if (SuperSonicCount <= 100)
        {
            SuperSonicCount += 10 * Time.deltaTime;

        }
        if (SuperSonicCount >= 100)
        {
            isSuper = true;
        }
        else
        {
            isSuper = false;
        }
        if(isSuper)
        {
            lightning.Play();
        }
        else
        {
            lightning.Stop();
        }
    }
    public void HealtSystem()
    {
        
        HealthBar.value = Health;
        HealthBar.gameObject.transform.LookAt(Camera.main.transform.position);
        if(Health == 0)
        {
            gm.isRestart = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NormalPunch")
        {
            anim.SetTrigger("GetHit");
            Instantiate(NormalPunchImpact, transform.position + new Vector3(0,1,0), transform.rotation);
            aus.clip = PunchFX;
            aus.Play();
            Health -= 20;
            if(Health <= 0)
            {
                anim.enabled = false;
                GetComponent<Collider>().enabled = false;
                Instantiate(SuperSonicImpact, transform.position + new Vector3(0, 1, 0), transform.rotation);
                aus.clip = SPunchFX;
                aus.Play();
            }
        }

        if (other.gameObject.tag == "SuperPunch")
        {
            anim.enabled = false;
            GetComponent<Collider>().enabled = false;
            Instantiate(SuperSonicImpact, transform.position + new Vector3(0, 1, 0), transform.rotation);
            aus.clip = SPunchFX;
            aus.Play();
            Health = 0;
        }

        if(other.gameObject.tag == "PowerUp")
        {
            SuperSonicCount += 50;
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.tag == "Enemy")
        {
            
                int rnd = Random.Range(-10, 10);
                other.GetComponent<Rigidbody>().velocity = new Vector3(rnd, 0, 8);
            
         
        }

        if (other.gameObject.tag == "Jump")
        {
            
            jumpAt = true;
            
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!jumpAt)
            {
                int rnd = Random.Range(-20, 20);
                int rndy = Random.Range(1, 10);
                if (rnd < 10)
                    rnd += 5;
                if (rnd > -10)
                    rnd -= 5;

                collision.gameObject.GetComponent<Animator>().SetBool("Run", false);
                collision.gameObject.GetComponent<Animator>().enabled = false;
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(rnd, rndy, 15);

                Destroy(collision.gameObject, 2f);
            }
                
            
        }
    }
    //Animation Events
    //public void OpenColls()
    //{

    //        if (SuperSonicCount >= 100)
    //        {
    //            SuperPunch.enabled = true;
    //            //ead.SuperSonicCounter -= 100;
    //        }
    //        else
    //        {
    //            NormalPunch.enabled = true;
    //        }


    //}
    //public void CloseColls()
    //{
    //    if (SuperSonicCount >= 100)
    //    {
    //        SuperPunch.enabled = false;
    //        SuperSonicCount -= 100;
    //    }
    //    else
    //    {
    //        NormalPunch.enabled = false;
    //        SuperSonicCount -= 20;
    //    }
    //}

}
