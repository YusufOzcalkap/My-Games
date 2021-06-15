using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman2Kontrol : MonoBehaviour
{
    public GameObject target;
    public GameObject target1;
    public float Can;
    public GameObject Kas�k;
    public CapsuleCollider2D dusmanZ�rh�;
    private bool hareketizin;
    public float h�z;
    public Animator dusmanAnimator;
    Vector3 yon;
    bool attack;
    [SerializeField] float currenttimerattack;
    [SerializeField] float defaulttimerattack;
    bool at�sIz�n;
    public AudioSource baltaSes;
    // Start is called before the first frame update
    void Start()
    {
        at�sIz�n = false;
        attack = false;
        hareketizin = false;
        dusmanZ�rh� = GetComponent<CapsuleCollider2D>();

        yon = new Vector3(-0.5f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (hareketizin == true)
        {
            if (target.transform.position.x > transform.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, h�z * Time.deltaTime);
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (target.transform.position.x < transform.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, h�z * Time.deltaTime);
                transform.localScale = new Vector3(1, 1, 1);
            }

        }

        if (target1.transform.position.x <= target.transform.position.x)
        {
            hareketizin = true;
            dusmanAnimator.SetTrigger("walk");
            attack = false;
            at�sIz�n = true;
        }

        if (Can <= 0)
        {
            dusmanAnimator.SetTrigger("Die");
            h�z = 0;
            Destroy(gameObject, 2f);

        }

        if(attack == false && at�sIz�n == true)
        {
            dusmanAnimator.SetTrigger("Attack");      
            attack = true;
        }

        if (attack == true)
        {
            currenttimerattack -= Time.deltaTime;
        }

        if (currenttimerattack <= 0)
        {
            currenttimerattack = defaulttimerattack;
            StartCoroutine(Wait(Kas�k));
            attack = false;
        }
     
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kas�k"))
        {
            Debug.Log("Vuruldu");
            Can--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dusmanAnimator.SetTrigger("Attack");

        }
    }

    void Fire()
    {
        StartCoroutine(Wait(Kas�k));

       
    }

    IEnumerator Wait(GameObject okum)
    {
        yield return new WaitForSecondsRealtime(0.5f);

        GameObject okumuz = Instantiate(Kas�k, transform.position + yon, Quaternion.identity);

        baltaSes.Play();

        if (transform.localScale.x < 0)
        {
            okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0f); //ok sa�a do�ru

        }
        else
        {
            Vector3 okumuzscale = okumuz.transform.localScale;
            okumuz.transform.localScale = new Vector3(-okumuzscale.x, okumuzscale.y, okumuzscale.z);
            okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);// ok sola do�ru

        }

        Destroy(okumuz, 3f);

    }
}
