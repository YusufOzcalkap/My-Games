using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;

    public Transform firstField;
    public Transform Girls;
    private Transform enemyTarget;
    private Animator anim;
    private float speed;
    public float speedGo;
    public float dist;
    public GameManager Gm;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        anim.SetBool("Walk", true);

        Gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        instance = this;

        Rigidbody[] rg = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody childcol in rg)
        {
            childcol.isKinematic = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!Gm.isStart)
        {
            speed = 0;
        }
        else
        {
            speed = speedGo;
        }

        dist = Vector3.Distance(transform.position, Girls.transform.position);

        //if (dist <= 8)
        //{
        //    print("dur");
        //    speed = 0;
        //    transform.GetChild(1).gameObject.SetActive(true);
        //    //transform.GetChild(1).GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
        //    //transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
        //    transform.LookAt(girl);
        //    Vector3 fark = Camera.main.transform.position - transform.GetChild(1).transform.position;
        //    transform.GetChild(1).rotation = Quaternion.LookRotation(-fark);
        //    anim.SetBool("Walk", false);
        //    StartCoroutine(SetEnemy());
        //}

        if (dist <= 5)
        {
            print("dur2");
            speedGo = 0;
            transform.GetChild(1).gameObject.SetActive(true);
            //transform.GetChild(1).GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
            //transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
            transform.LookAt(Girls);
            Vector3 fark = Camera.main.transform.position - transform.GetChild(1).transform.position;
            transform.GetChild(1).rotation = Quaternion.LookRotation(fark);
            anim.SetBool("Walk", false);
            StartCoroutine(SetEnemy());
            // heartMeter.fillAmount -= 0.2f;
            girl.instance.heartMeter.fillAmount -= 0.0015f;
          
        }



        // First Run
        if (transform.gameObject.GetComponentInChildren<EnemyForce>().goGirl == false)
        {
            transform.position = Vector3.Lerp(transform.position, firstField.position, speed * Time.deltaTime);
            transform.LookAt(firstField);
        }
     

        if (transform.gameObject.GetComponentInChildren<EnemyForce>().goGirl == true)
        {
            transform.position = Vector3.Lerp(transform.position, Girls.position, speed * (Time.deltaTime * 2));
            transform.LookAt(Girls);
        }
    }

    public void ragdollOn()
    {
        Rigidbody[] rg = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody childcol in rg)
        {
            childcol.isKinematic = false;
        }
    }

    public void velocityOn()
    {
        Rigidbody[] rg = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody childcol in rg)
        {
            childcol.velocity = new Vector3(2,4.5f,10);
        }
    }

    IEnumerator SetEnemy()
    {
        yield return new WaitForSeconds(5f);
        speedGo = 0.1f;
        speed = speedGo;
        anim.SetBool("Walk", true);
        //   Destroy(transform.GetChild(1).gameObject);
        //transform.GetChild(1).GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
        //transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
}
