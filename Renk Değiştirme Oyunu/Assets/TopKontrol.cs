using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    public float Hýz = 15f;
    public Color pembe;
    public Color Mor;
    public string MevcutRenk;
    public Text ScoreText;
    public static int Score;
    public GameObject Daire;
    public GameObject RenkCemberi;

    // Start is called before the first frame update
    void Start()
    {
        RastgeleRenkBelirle();
        ScoreText.text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * Hýz;
        }
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Skoru Arttýr")
        {
            Score += 50;
            ScoreText.text = Score.ToString();
            Instantiate(Daire, new Vector3(transform.position.x, transform.position.y + 12f, transform.position.z),Quaternion.identity);
        }

        if (collision.tag == "RenkTekeri")
        {
            RastgeleRenkBelirle();
            Destroy(collision.gameObject);
            Instantiate(RenkCemberi, new Vector3(transform.position.x, transform.position.y + 12f, transform.position.z), Quaternion.identity);
            return;
            
        }

        if (collision.tag != MevcutRenk && collision.tag != "Skoru Arttýr")
        {
            Score = 0;
            ScoreText.text = Score.ToString();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        
    }

    void RastgeleRenkBelirle()
    {
        int RastgeleSayý = Random.Range(0, 4);

        switch (RastgeleSayý)
        {
            case 0: 
                MevcutRenk = "Turkuaz";
                GetComponent<SpriteRenderer>().color = Color.cyan;
                break;

            case 1:
                MevcutRenk = "Sarý";
                GetComponent<SpriteRenderer>().color = Color.yellow;
                break;

            case 2:
                MevcutRenk = "Pembe";
                GetComponent<SpriteRenderer>().color = pembe;
                break;

            case 3:
                MevcutRenk = "Mor";
                GetComponent<SpriteRenderer>().color = Mor;
                break;
        }
       //GetComponent<SpriteRenderer>().color = MevcutRenk;
    }
}
