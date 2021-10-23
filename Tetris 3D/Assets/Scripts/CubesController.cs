using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesController : MonoBehaviour
{
    public static CubesController instance;
    public List<GameObject> players = new List<GameObject>();

    public int count = 0;
    public int count2 = 0;
    private int count3 = 0;
    private int count4 = 0;

    public BoxCollider[] rightCol;
    public BoxCollider[] leftCol;
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        //if (GameManager.instance.height == 1)
        //{
        //    count++;
        //    if (count == 1)
        //    {
        //      //  transform.GetComponent<BoxCollider>().center = new Vector3(transform.GetComponent<BoxCollider>().center.x, transform.GetComponent<BoxCollider>().center.y, 0.50f);
        //    //    transform.GetComponent<BoxCollider>().size = new Vector3(0.16f, 0.41f, 0.07f);
        //    }

        //}

        //if (GameManager.instance.height == 2)
        //{
        //    count3++;
        //    if (count3 == 1)
        //    {
        //       // transform.GetComponent<BoxCollider>().center = new Vector3(transform.GetComponent<BoxCollider>().center.x, transform.GetComponent<BoxCollider>().center.y, 1f);
        //      //  transform.GetComponent<BoxCollider>().size = new Vector3(0.16f, 0.41f, 0.07f);
        //    }

        //}

        //if (GameManager.instance.height == 3)
        //{
        //    count4++;
        //    if (count4 == 1)
        //    {
        //     //   transform.GetComponent<BoxCollider>().center = new Vector3(transform.GetComponent<BoxCollider>().center.x, transform.GetComponent<BoxCollider>().center.y, 1.5f);
        //    //    transform.GetComponent<BoxCollider>().size = new Vector3(0.16f, 0.41f, 0.07f);
        //    }

        //}

        //if (GameManager.instance.height == 0)
        //{
        //    count2++;
        //    if (count2 == 1)
        //    {
        //    //    transform.GetComponent<BoxCollider>().center = new Vector3(transform.GetComponent<BoxCollider>().center.x, transform.GetComponent<BoxCollider>().center.y, 0.15f);
        //    }
        //}
    }

    public void CubesDestroyed()
    {
        for (int i = 0; i < players.Count; i++)
        {
            Destroy(players[i]);
        
        }
        players.Clear();
      //  GameManager.instance.CreatePlayers();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            TouchController.instance.speedModifier = 0.003f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            TouchController.instance.speedModifier = 0.005f;
        }
    }
}
