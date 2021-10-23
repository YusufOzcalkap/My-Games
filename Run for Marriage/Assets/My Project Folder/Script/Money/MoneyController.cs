using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public static MoneyController instance;

    public int direction;
    public float MoneySpeed;

    void Start()
    {
        instance = this;
        direction = -1;

        MoneySpeed = Random.Range(0.6f, 1.4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).Translate(transform.up * Time.deltaTime * direction * MoneySpeed);

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Down"))
    //    {
    //        print("vurdu");
    //        direction = 1;
    //    }

    //    if (other.gameObject.CompareTag("Up"))
    //    {
    //        direction = -1;
    //    }
    //}
}
