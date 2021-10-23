using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossComingSc : MonoBehaviour
{
    Animator anim;
    public float downSpeed;
    public GameObject DownImpact;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            anim.SetBool("isGround", true);
            downSpeed = 0;
            Instantiate(DownImpact, other.gameObject.transform.position, other.gameObject.transform.rotation);
        }
    }
}
