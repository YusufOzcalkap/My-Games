using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainEnemy : MonoBehaviour
{
    public Transform Home;
    NavMeshAgent agent;

    private Animator anim;
    public ParticleSystem Hit;

    public float dist;
    public float distancePlayer;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Home.position);
        //transform.position = Vector3.Lerp(transform.position, Home.position, 0.15f * Time.deltaTime);


        dist = Vector3.Distance(Home.position, transform.position);

        if (GameManager.instance.MainEnemyGo)
        {
            if (dist > distancePlayer)
            {
                agent.speed = 2.5f;
            }

            if (dist < distancePlayer)
            {
                agent.speed = 1.5f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
        }
    }

    public void SetDamage()
    {
        HealthBar.instance.Health -= GameManager.instance.EnemyAttack;
        HealthBar.instance.DamageOn = true;

        ParticleSystem hitEffect = Instantiate(Hit);
        hitEffect.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z +1);
        CameraController.instance.SetCamera();
    }

    public void SetSpeedStart()
    {
        agent.speed = 0;
    }

    public void SetSpeedEnd()
    {
        agent.speed = 1.5f;
    }
}
