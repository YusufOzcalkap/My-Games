using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKontrol : MonoBehaviour
{
    public float h�z;
    private Rigidbody rigi;

    public Animator anim;

    public Transform Kursun;

    public TextMeshProUGUI CanSay�;
    public float Can�m;

    public GameObject Panel;

    public GameObject Dost1;
    public GameObject Dost2;
    public GameObject Dost3;

    public GameObject Close;



    public AudioSource DansSesi;


    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();

        CanSay�.text = Can�m.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        rigi.velocity = new Vector3(0f, 0f, h�z * Time.deltaTime);

        if (Input.anyKey)
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                anim.SetTrigger("sol");
            }
            if (Input.mousePosition.x > Screen.width / 2 )
            {
                if (Kursun.transform.position.x > 0)
                {
                    
                }
                anim.SetTrigger("sag");
            }

            
        }

        if (Can�m <= 0)
        {
            anim.SetTrigger("Dead");
            SceneManager.LoadScene("Restart");
            Invoke("Zaman�Durdur", 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kursun"))
        {
            Debug.Log("kursun vurdu");

            Can�m--;

            CanSay�.text = Can�m.ToString();

        }

        if (other.gameObject.CompareTag("Finish"))
        {
            anim.SetTrigger("Finish");
            Panel.gameObject.SetActive(true);
            Dost1.gameObject.SetActive(false);
            Dost2.gameObject.SetActive(false);
            Dost3.gameObject.SetActive(false);
            Close.gameObject.SetActive(false);


            DansSesi.Play();
            h�z = 0;

        }
    }

    void Zaman�Durdur()
    {
        Time.timeScale = 0;
    }

    public void SonSahne(string isim)
    {
        SceneManager.LoadScene(isim);
    }
}
