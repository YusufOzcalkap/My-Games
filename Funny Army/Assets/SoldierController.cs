using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class SoldierController : MonoBehaviour
{
    public float distance;

    [Header("1 Mage 2archer 3pikeman 4swordsman 5farmer")]
    public float SoldierIndex;

    public Transform tMin;
    public float dist;
    public List<Transform> children = new List<Transform>();

    public Transform Home;
    NavMeshAgent agent;

    private Animator anim;
    private Animator Horseanim;

    [Header("           Soldier Damage and Defense")]
    public float Health;
    [Header("Damage")]
    public float magicDamage;
    public float ArrowDamage;
    public float SwordDamage;
    public float PikeDamage;
    public float SpearDamage;
    public float FarmerDamage;
    [Header("Defence")]
    public float cutDefense;
    public float piercingDefense;
    public float arrowDefense;
    public float smashDefense;
    public float magicDefense;

    public Rigidbody[] rg;

    private float Count;
    private float CountLeftHand;
    private Vector3 hipsForward;
    private int a, b, c;
    public GameObject RightHand;
    public GameObject LeftHand;

    void Awake()
    {
        if (SoldierIndex != 2)
            RightHand = transform.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;

        

        anim = transform.GetChild(1).GetComponent<Animator>();
        if (transform.childCount == 3)
        {
            Horseanim = transform.GetChild(2).GetComponent<Animator>();
        }

        agent = GetComponent<NavMeshAgent>();

        a = Random.Range(0, 7);
        b = Random.Range(0, 7);
        c = Random.Range(0, 7);
    }
    
    void Update()
    {
        children = GameManager.instance.Enemies.transform.Cast<Transform>().ToList();

        hipsForward = new Vector3(transform.GetChild(0).transform.GetChild(0).position.x + a, transform.GetChild(0).transform.GetChild(0).position.y + b, (transform.GetChild(0).transform.GetChild(0).position.z + 3) +c);

        GetClosestEnemy(children);

        CountLeftHand++;
        if (this.Health > 0 && CountLeftHand == 1 && SoldierIndex == 1)
        {
            this.LeftHand = transform.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        }

        if (this.Health > 0 && CountLeftHand == 1 && SoldierIndex == 2)
        {
            this.LeftHand = transform.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        }

        if (this.Health > 0 && CountLeftHand == 1 && SoldierIndex == 3)
        {
            this.LeftHand = transform.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        }

        if (this.Health <= 0)
        {
            this.Count++;

            if (this.Count == 1)
            {
                SetExplosion();
                transform.parent = null;
                transform.parent = GameManager.instance.Rubish.transform;
            }
        }

        // Soldier Win
        if (GameManager.instance.Enemies.transform.childCount == 0)
        {
            tMin = null;
            Home = null;
            anim.SetBool("Walk", false);
            anim.SetBool("Attack", false);
            agent.enabled = false;
            agent.speed = 0;
            if (SoldierIndex == 6) Horseanim.SetBool("isRunning", false);

            GameManager.instance.WinPanel.gameObject.SetActive(true);
        }

        if (GameManager.instance.Enemies.transform.childCount != 0)
        {
        // Mage Controller
        if (SoldierIndex == 1 && tMin.gameObject != null)
        {
            dist = Vector3.Distance(tMin.position, transform.position);

            if (GameManager.instance.gameStart && dist > 10)
            {
                anim.SetBool("Walk", true);
                Home = tMin;
                agent.enabled = true;
                agent.speed = 2;
                agent.SetDestination(Home.position);
            }

            if (dist <= 10)
            {
                agent.speed = 0;
                anim.SetBool("Walk", false);
                anim.SetBool("Attack", true);
            }

        }

        // Archer
        if (SoldierIndex == 2 && tMin.gameObject != null)
        {
            dist = Vector3.Distance(tMin.position, transform.position);

            if (GameManager.instance.gameStart && dist > 15)
            {
                anim.SetBool("Walk", true);
                Home = tMin;
                agent.enabled = true;
                agent.speed = 2;
                agent.SetDestination(Home.position);
            }

            if (dist <= 15)
            {
                agent.speed = 0;
                anim.SetBool("Walk", false);
                anim.SetBool("Attack", true);
            }
        }

        // Pikeman Controller
        if (SoldierIndex == 3 && tMin.gameObject != null)
        {
            dist = Vector3.Distance(tMin.position, transform.position);

            if (GameManager.instance.gameStart && dist > 3)
            {
                anim.SetBool("Walk", true);
                Home = tMin;
                agent.enabled = true;
                agent.speed = 2;
                agent.SetDestination(Home.position);
            }

            if (dist <= 3)
            {
                agent.speed = 0;
                anim.SetBool("Walk", false);
                anim.SetBool("Attack", true);
            }
        }

        // Swordsman Controller
        if (SoldierIndex == 4 && tMin.gameObject != null)
        {
            dist = Vector3.Distance(tMin.position, transform.position);

            if (GameManager.instance.gameStart && dist > 3)
            {
                anim.SetBool("Walk", true);
                Home = tMin;
                agent.enabled = true;
                agent.speed = 2;
                agent.SetDestination(Home.position);
            }

            if (dist <= 3)
            {
                agent.speed = 0;
                anim.SetBool("Walk", false);
                anim.SetBool("Attack", true);
            }
        }

        // Farmer Controller
        if (SoldierIndex == 5 && tMin.gameObject != null)
        {
            dist = Vector3.Distance(tMin.position, transform.position);

            if (GameManager.instance.gameStart && dist > 3)
            {
                anim.SetBool("Walk", true);
                Home = tMin;
                agent.enabled = true;
                agent.speed = 2;
                agent.SetDestination(Home.position);
            }

            if (dist <= 3)
            {
                agent.speed = 0;
                anim.SetBool("Walk", false);
                anim.SetBool("Attack", true);
            }
        }

            // Cavalier Controller
            if (SoldierIndex == 6 && tMin.gameObject != null)
            {
                dist = Vector3.Distance(tMin.position, transform.position);

                if (GameManager.instance.gameStart && dist > 3)
                {
                    // anim.SetBool("Walk", true);
                    anim.SetBool("Attack", false);
                    Horseanim.SetBool("isRunning", true);
                    Home = tMin;
                    agent.enabled = true;
                    agent.speed = 2;
                    agent.SetDestination(Home.position);
                }

                if (dist <= 3)
                {
                    agent.speed = 0;
                    // anim.SetBool("Walk", false);
                    anim.SetBool("Attack", true);
                    Horseanim.SetBool("isRunning", false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyFarmer"))
        {
            this.Health -= FarmerDamage - piercingDefense;
        }

        if (other.gameObject.CompareTag("EnemySword"))
        {
            this.Health -= SwordDamage - cutDefense;
        }

        if (other.gameObject.CompareTag("EnemySpear"))
        {
            this.Health -= PikeDamage - piercingDefense;
        }

        if (other.gameObject.CompareTag("Magic"))
        {
            this.Health -= magicDamage - magicDefense;
        }

        if (other.gameObject.CompareTag("Arrow"))
        {
            this.Health -= ArrowDamage - arrowDefense;
        }

        if (other.gameObject.CompareTag("EnemyCavalier"))
        {
            print("Vuruyor");
            this.Health -= SpearDamage - piercingDefense;
        }

    }

    private void SetExplosion()
    {
        anim.enabled = false;
        if (RightHand != null)
        {
            RightHand.transform.parent = null;
            RightHand.GetComponent<Rigidbody>().AddExplosionForce(500, hipsForward, 250f, 3);
            RightHand.transform.parent = GameManager.instance.Rubish.transform;
        }
        if (LeftHand != null)
        {
            LeftHand.transform.parent = null;
            LeftHand.GetComponent<Rigidbody>().AddExplosionForce(500, hipsForward, 250f, 3);
            LeftHand.transform.parent = GameManager.instance.Rubish.transform;
        }

        transform.GetComponent<BoxCollider>().enabled = false;
        transform.GetComponent<RagdollController>().enabled = false;
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);

        if (SoldierIndex >= 1 && SoldierIndex <= 6)
        {
            rg = transform.GetChild(0).GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody childcol in rg)
            {

                childcol.AddExplosionForce(500, hipsForward, 250f, 3);
            }
        }
    }
    Transform GetClosestEnemy(List<Transform> enemies)
    {
        tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

}
