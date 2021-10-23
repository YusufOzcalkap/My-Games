using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public GameObject MoneyCount;
    public Image  Money;
    public GameObject  Canvas;

    public TextMeshProUGUI MoneyText;

    public GameObject Ring;
    private Animator anim;
    public Transform propoes;
    public GameObject Girl;
    public GameObject Diamond;
    public ParticleSystem Steal;

    public float ds;
    [Header("Count")]
    public bool Move;
    public bool Finish;
    public float DirectionPlus;
    public bool dr;
    public float DirectionPlus1;
    public bool dr1;
    float ar;
    public bool dr2;
    int Count;
    public bool dr3;
    public float rotation;
    float a;
    float b;
    bool buyu;

    [Header("Thief")]
    public Animator Thiefanim;
    public int StealMoney;
    public TextMeshProUGUI thiefText;
    public Image ThiefMoney;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
        Move = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // transform.rotation = Quaternion.Euler(0, 0, 0);

        ds  = Vector3.Distance(transform.parent.transform.position, propoes.position);

        if (ds < 3)
        {
            Gamemanager.instance.PlayerSpeed = 0;
            buyu = true;
            anim.SetTrigger("Kneel");
            transform.LookAt(new Vector3(Girl.transform.position.x, transform.position.y, Girl.transform.position.z));
        }

        if (buyu)
        {
            Ring.transform.localScale = new Vector3(Mathf.Lerp(-17f, 100f * Gamemanager.instance.Emerald , 0.01f + b), Mathf.Lerp(-17f, 100f * Gamemanager.instance.Emerald, 0.01f + b), Mathf.Lerp(-17f, -100f * Gamemanager.instance.Emerald, 0.01f + b));
            b += 0.005f;
        }

        if (dr)
        {
            transform.parent.transform.rotation = Quaternion.Euler(transform.rotation.x, Mathf.Lerp(transform.parent.transform.rotation.y , rotation, 0.0001f + DirectionPlus), transform.rotation.z); ;
            DirectionPlus += 0.01f;
            if (DirectionPlus >= 1)
            {
                dr = false;
                DirectionPlus = 0;
            }
        }

        if (dr1)
        {
            //transform.parent.transform.rotation = Quaternion.Lerp(transform.rotation.x, Mathf.Lerp(transform.parent.transform.rotation.y, rotation, 0.0001f + DirectionPlus1), transform.rotation.z); 
            transform.parent.transform.rotation = Quaternion.Lerp(transform.parent.transform.rotation, Quaternion.Euler(0, rotation, 0), 3 * Time.deltaTime);

            DirectionPlus1 -= 0.01f;

            if (DirectionPlus1 <= -1)
            {
                dr1 = false;
                DirectionPlus1 = 0;
            }
        }

        //if (rotation == 0)
        //{
        //    transform.parent.transform.rotation = Quaternion.Euler(transform.rotation.x, Mathf.Lerp(transform.parent.transform.rotation.y, rotation, 0.0001f + DirectionPlus), transform.rotation.z); ;
        //    DirectionPlus += 0.01f;
        //}

        if (dr2)
        {
            Gamemanager.instance.EmeraldCount.fillAmount = Mathf.Lerp(Gamemanager.instance.EmeraldCount.fillAmount, Gamemanager.instance.FillAmount, 0.0001f + a);
            a += 0.01f;
        }

        if (dr3)
        {
            Gamemanager.instance.EmeraldCount.fillAmount = Mathf.Lerp(Gamemanager.instance.EmeraldCount.fillAmount, Gamemanager.instance.FillAmount, 0.0001f + a);
            a -= 0.001f;
        }

    }

    private void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            Destroy(other.gameObject);
            Gamemanager.instance.Money += 10;
            Image createImage = Instantiate(Money);
            createImage.transform.SetParent(Canvas.transform);
            createImage.transform.GetComponent<RectTransform>().position = new Vector3(0.5f,0.5f,transform.position.z);
            createImage.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(25, 25);

            TextMeshProUGUI createText = Instantiate(MoneyText);
            createText.transform.SetParent(Canvas.transform);
            createText.transform.GetComponent<RectTransform>().position = new Vector3(0.5f, 0.5f , transform.position.z);
            //createImage.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(25, 25);
            Destroy(createImage.gameObject, 0.55f);
            Destroy(createText.gameObject, 0.4f);


            //  createImage.transform.position = Vector3.Lerp(other.transform.position, MoneyCount.transform.position , 0.0001f);
        }

        if (other.gameObject.CompareTag("BlueWall"))
        {
            a = 0;
            Gamemanager.instance.FillAmount += 0.7f;
            dr2 = true;
            Gamemanager.instance.Emerald += 2;
            
            int rnd = Random.Range(0,10);
            if (rnd >= 5)
            {
                anim.SetTrigger("Dance");
            }
            if (rnd < 5)
            {
                anim.SetTrigger("Dance1");
            }
        }

        if (other.gameObject.CompareTag("RedWall"))
        {
            a = 0;
            Gamemanager.instance.FillAmount -= 0.2f;
            dr3 = true;
            Gamemanager.instance.Emerald--;

        }

        if (other.gameObject.CompareTag("Finish"))
        {
            anim.SetTrigger("FinishLine");
            Gamemanager.instance.PlayerSpeed = 3;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            transform.parent.transform.position = new Vector3(Girl.transform.position.x, transform.position.y, transform.position.z);
       //     transform.parent.transform.position = Vector3.Lerp(transform.parent.transform.position, propoes.position, 0.1f);
            //transform.parent.transform.position = Vector3.MoveTowards(transform.parent.transform.position, propoes.position, 1f);

        }

        if (other.gameObject.CompareTag("Thief"))
        {
            Thiefanim.SetTrigger("Steal");
            StartCoroutine(SetSteal());
            Gamemanager.instance.Money -= StealMoney;

            Image createImage = Instantiate(ThiefMoney);
            createImage.transform.SetParent(Canvas.transform);
            createImage.transform.GetComponent<RectTransform>().position = new Vector3(0.5f, 0.5f, transform.position.z);
            createImage.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(25, 25);

            TextMeshProUGUI createText = Instantiate(thiefText);
            createText.transform.SetParent(Canvas.transform);
            createText.transform.GetComponent<RectTransform>().position = new Vector3(0.5f, 0.5f, transform.position.z);
            //createImage.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(25, 25);
            Destroy(createImage.gameObject, 0.55f);
            Destroy(createText.gameObject, 0.4f);
        }

        if (other.gameObject.CompareTag("RightWall"))
        {
            dr = true;
            //    TouchController.instance.yon = new Vector3(1, 0, 0);
            //  transform.rotation = Quaternion.Euler(transform.rotation.x, Mathf.Lerp(0, 90, 1 + DirectionPlus), transform.rotation.z); ;
            rotation += 90;
            TouchController.instance.index++;
            StartCoroutine(SetTouch());
        }

        if (other.gameObject.CompareTag("LeftWall"))
        {
            dr1 = true;
            //    TouchController.instance.yon = new Vector3(1, 0, 0);
            //  transform.rotation = Quaternion.Euler(transform.rotation.x, Mathf.Lerp(0, 90, 1 + DirectionPlus), transform.rotation.z); ;
            rotation -= 90;
            TouchController.instance.index++;
            StartCoroutine(SetTouch());

        }
    }


    // Dance Animasyon fonksiyonlar
    public void SetDanceStart()
    {
        Gamemanager.instance.PlayerSpeed = 5;
    }

    public void SetDanceFinish()
    {
        Gamemanager.instance.PlayerSpeed = 8;
    }

    public void SetRing()
    {
        print("Ring");
        Diamond.gameObject.SetActive(true);
    }


    public void SetRingFinish()
    {
        Finish = true;
    }
    IEnumerator SetTouch()
    {
        Move = false;
        yield return new WaitForSeconds(1f);
        Move = true;

    }

    IEnumerator SetSteal()
    {
        yield return new WaitForSeconds(0.4f);
        Steal.Play();

    }
}
