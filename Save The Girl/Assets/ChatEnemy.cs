using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatEnemy : MonoBehaviour
{
    public Transform Girls;
    public float dist;
    private Animator anim;
    public float speed;
    public float speedGo;
    public bool run;

    int count = 0;
    int count2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
       

        Rigidbody[] rg = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody childcol in rg)
        {
            childcol.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        speed = speedGo;
        dist = Vector3.Distance(transform.position, Girls.transform.position);

        
        if (dist <= 16)
        {
            StartCoroutine(SetWalk());
            count++;
            if (count == 1)
            {
                StartCoroutine(SetWalks());
                Vector3 fark = Camera.main.transform.position - transform.GetChild(1).position;
                transform.GetChild(1).rotation = Quaternion.LookRotation(fark);
                StartCoroutine(SetBubble());
            }
            //transform.LookAt(girl);
        }

        if (dist <= 5)
        {
            count2++;
            if (count2 == 1)
            {
                anim.SetBool("Walk", false);
                speedGo = 0;
                transform.GetChild(1).gameObject.SetActive(true);
                //transform.GetChild(1).GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
                //transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
                transform.LookAt(Girls);
                Vector3 fark = Camera.main.transform.position - transform.GetChild(1).transform.position;
                transform.GetChild(1).rotation = Quaternion.LookRotation(-fark);
                anim.SetBool("Walk", false);
                StartCoroutine(SetBubble());
                StartCoroutine(SetEnemy());
                girl.instance.heartMeter.fillAmount -= 0.0015f;
            }
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
            childcol.velocity = new Vector3(2, 4.5f, 10);
        }
    }

    IEnumerator SetBubble()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(6f);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = false;
      // Destroy(transform.GetChild(1).gameObject);
    }


    IEnumerator SetWalk()
    {
        yield return new WaitForSeconds(10f);
        transform.position = Vector3.Lerp(transform.position, Girls.position, speed * Time.deltaTime * 2);
        transform.LookAt(Girls);
     //   anim.SetBool("Walk", true);
    }

    IEnumerator SetWalks()
    {
        yield return new WaitForSeconds(10f);
           anim.SetBool("Walk", true);
    }

    IEnumerator SetEnemy()
    {
        yield return new WaitForSeconds(5f);
        speedGo = 0.1f;
        //speed = speed;
        anim.SetBool("Walk", true);
        //   Destroy(transform.GetChild(1).gameObject);
        //transform.GetChild(1).GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
        //transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
}
