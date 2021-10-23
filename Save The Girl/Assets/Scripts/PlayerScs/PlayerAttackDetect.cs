using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDetect : MonoBehaviour
{
    public static PlayerAttackDetect instance;

    public Animator anim;
   

    private ParticleSystem ps;
   

    public bool jumpAttack;
    public bool jumpAt = false;
    void Start()
    {
        instance = this;
        
    }


    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        // Enemy Attack
        if (PlayerScript.instance.jumpAt == false)
        {
            if (other.gameObject.tag == "Enemy")
            {
                //other.transform.GetChild(1).GetChild(1).GetComponent<MeshRenderer>().enabled = false;
              //  Destroy(other.transform.parent.transform.GetChild(1).gameObject , 1f);
                other.GetComponent<CapsuleCollider>().enabled = false;
                StartCoroutine(SetAttack(other));

                Destroy(other.transform.parent.gameObject, 3f);

            }
        }

        if (PlayerScript.instance.jumpAt == false)
        {
            if (other.gameObject.tag == "EnemyChat")
            {
                //Destroy(other.transform.parent.transform.GetChild(1).gameObject, 1f);
                other.GetComponent<CapsuleCollider>().enabled = false;
                StartCoroutine(SetAttack(other));

                Destroy(other.transform.parent.gameObject, 3f);

            }
        }


        if (other.gameObject.tag == "Water")
        {
           

            int atc = Random.Range(1, 3);

            if (atc == 1)
                anim.SetTrigger("LeftKick");
            if (atc == 2)
                anim.SetTrigger("RightKick");
           

            StartCoroutine(SetWater(other));

        }

        if (other.gameObject.tag == "Jump")
        {

            jumpAt = true;

        }
    }

    

    public IEnumerator SetAttack(Collider col)
    {
        yield return new WaitForSeconds(0.1f);

        int atc = Random.Range(1, 3);

        if (atc == 1)
        {
            anim.SetBool("Attack", true);
            anim.SetBool("UpperAttack", false);
            anim.SetBool("LeftKick", false);
            anim.SetBool("RightKick", false);
        }


        if (atc == 2)
        {
            anim.SetBool("UpperAttack", true);
            anim.SetBool("LeftKick", false);
            anim.SetBool("RightKick", false);
            anim.SetBool("Attack", false);
        }

        if (atc == 3)
        {
            anim.SetBool("LeftKick", true);
            anim.SetBool("RightKick", false);
            anim.SetBool("Attack", false);
            anim.SetBool("UpperAttack", false);
        }

        if (atc == 4)
        {
            anim.SetBool("RightKick", true);
            anim.SetBool("Attack", false);
            anim.SetBool("UpperAttack", false);
            anim.SetBool("LeftKick", false);
        }

        yield return new WaitForSeconds(0.6f);

        //Enemy.instance.ragdollOn();
        //Enemy.instance.velocityOn();

        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponentInParent<Enemy>().ragdollOn();
            //col.gameObject.GetComponentInParent<Enemy>().velocityOn();
            col.gameObject.GetComponent<EnemyForce>().rgSpine.velocity = new Vector3(0, 40, 20);

        }
        else
        {
            col.gameObject.GetComponent<Animator>().enabled = false;
            col.gameObject.GetComponentInParent<ChatEnemy>().ragdollOn();
            //col.gameObject.GetComponentInParent<ChatEnemy>().velocityOn();
            col.gameObject.GetComponent<EnemyForce>().rgSpine.velocity = new Vector3(0, 40, 20);
        }


        int rnd = Random.Range(-20, 20);
        int rndy = Random.Range(1, 10);
        if (rnd < 10)
            rnd += 5;
        if (rnd > -10)
            rnd -= 5;

        col.gameObject.GetComponent<Animator>().SetBool("Run", false);
        col.gameObject.GetComponent<Animator>().enabled = false;
        col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        col.gameObject.GetComponent<Rigidbody>().useGravity = true;
       // col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0,0);

        //col.gameObject.GetComponent<Rigidbody>().velocity = 100 * transform.forward;
        // col.GetComponentInChildren<Rigidbody>().velocity = new Vector3(rnd,rndy,5000);

        // col.transform.GetChild(1).GetComponent<Rigidbody>().velocity = 100 * transform.forward;

        anim.SetBool("RightKick", false);
        anim.SetBool("Attack", false);
        anim.SetBool("UpperAttack", false);
        anim.SetBool("LeftKick", false);
        //col.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200000);
    }

    IEnumerator SetWater(Collider col)
    {
        yield return new WaitForSeconds(0.6f);
        ps = col.transform.parent.GetChild(0).GetComponent<ParticleSystem>();
        ps.Play();

        int rnd = Random.Range(-20, 20);
        int rndy = Random.Range(1, 10);
        if (rnd < 10)
            rnd += 5;
        if (rnd > -10)
            rnd -= 5;

        
        col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        col.gameObject.GetComponent<Rigidbody>().useGravity = true;
        col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(rnd, rndy, 7);

        anim.SetBool("RightKick", false);
        anim.SetBool("LeftKick", false);
        yield return new WaitForSeconds(2f);

        col.gameObject.SetActive(false);
    }
}
