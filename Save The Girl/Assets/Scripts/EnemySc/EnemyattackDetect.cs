using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyattackDetect : MonoBehaviour
{
    public float SuperSonicCounter;


    public Animator anim;

    public Collider punchCollider;
    public Collider SuperpunchCollider;

    public bool isSuperSonic;

    public ParticleSystem lightning;

    void Start()
    {
        Invoke("OpenDetectCollider", 1f);
    }


    void Update()
    {
        if (SuperSonicCounter <= 100)
        {
            SuperSonicCounter += 10 * Time.deltaTime;
        }
        if (SuperSonicCounter >= 100)
        {
            lightning.Play();
        }
        else
        {
            lightning.Stop();
        }
    }
    public void OpenDetectCollider()
    {
        GetComponent<Collider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            anim.SetTrigger("Attack");
        }
    }



}
