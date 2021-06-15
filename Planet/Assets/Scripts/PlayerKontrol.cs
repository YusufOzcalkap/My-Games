using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerKontrol : MonoBehaviour
{
    private float h�z = 200;
    private float Tak�lmamaH�z� = 500f;
    private float Yukar�uc = 5f;

    public Text SkorYaz�s�;

    public float Z�plamaGucu;

    public Rigidbody Player;

    public RectTransform Oksijen;
    public float OksijenSeviyesi;
    public float Oksijendusme = 100f;

    public AudioSource Z�pZ�p;


    public float Zaman;

    // Start is called before the first frame update
    void Start()
    {
        OksijenSeviyesi = 100;
        Player = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Oksijendusme -= 6 * Time.deltaTime;

        OksijenSeviyesi = Oksijendusme;

        Oksijen.sizeDelta = new Vector2(OksijenSeviyesi, Oksijen.sizeDelta.y);

        Zaman += Time.deltaTime * 5;

        if (Zaman == 20)
        {
            h�z = 5000;
        }

        

        Player.AddForce(transform.forward*Tak�lmamaH�z�);
        Player.AddForce(transform.up * Yukar�uc);


        if (Input.GetMouseButton(0))
        {
            Player.constraints = RigidbodyConstraints.FreezePositionY;
            Player.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if (Oksijendusme <= 0)
        {
            SceneManager.LoadScene(2);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (Zaman >= 50)
        {
            h�z = 300f;
        }

        if (Zaman >= 200)
        {
            h�z = 1000f;
        }

        if (Zaman >= 300)
        {
            h�z = 2000f;
        }

        if (collision.gameObject.tag == "Gezegen")
        {
            Player.velocity = new Vector3(0f, Z�plamaGucu, h�z*Time.deltaTime);
            Oksijendusme += 10;
            Debug.Log("Gezegene trigger vurud");
            Debug.Log(collision.gameObject.name);

            Z�pZ�p.Play();

        }

        if (collision.gameObject.tag == "Panel")
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Gezegen")
        {
            Player.velocity = new Vector3(0f, Z�plamaGucu, h�z * Time.deltaTime);
            
            Debug.Log("Gezegene stayde");

            Z�pZ�p.Play();

        }
    }

    

    
}
