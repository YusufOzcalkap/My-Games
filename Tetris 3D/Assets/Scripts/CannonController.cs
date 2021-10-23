using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    public static CannonController instance;
    
    public GameObject player;
    public GameObject ball;
    public Transform[] fireFields;
    private bool fire;
    public int direction;
    public int count;
    public bool fireOn;

    public Slider slide;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fire)
        {
            Vector3 fark = player.transform.position - transform.GetChild(1).transform.position;
            transform.GetChild(1).rotation = Quaternion.LookRotation(-fark);
        }

        if (fireOn)
        {
            count++;
            slide.value += 0.34f;
            fireOn = false;
            StartCoroutine(CountReset());
            if (count == 1 && slide.value >= 1)
            {
               
                StartCoroutine(CreateBall());
            }
            StartCoroutine(CountReset());
            count = 0;
            //  ballCannon.GetComponent<Rigidbody>().velocity = new Vector3(fireFields[0].position.x * 100, fireFields[0].position.y, fireFields[0].position.z);
            // ballCannon.GetComponent<Rigidbody>().AddForce(new Vector3(fireFields[0].position.x * 100, fireFields[0].position.y *100, fireFields[0].position.z*100));

        }

    }

    IEnumerator CreateBall()
    {
        
        TouchController.instance.speedModifier = 0;
        yield return new WaitForSeconds(1.5f);
        GameObject ballCannon = Instantiate(ball);
        ball.transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.366f, 0);
        yield return new WaitForSeconds(0.5f);
        count = 0;
        slide.value = 0f;
        TouchController.instance.speedModifier = 0.005f;
    }

    IEnumerator CountReset()
    {
        yield return new WaitForSeconds(1f);
        count = 0;
    }

    public void FinishBalls()
    {
        for (int i = 0; i < 10; i++)
        {
            StartCoroutine(CreateBall());
        }
    }
}
