using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public static Trap instance;

    public bool Active;
    public float Count;
    public float Count1;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
       // transform.GetChild(1).transform.localPosition = new Vector3(0, 0, transform.GetChild(1).position.z);
        if (Active == true)
        {
            // transform.GetChild(1).transform.Translate(transform.GetChild(1).transform.position.x, transform.GetChild(1).transform.position.y, 0.0026f);
            //transform.GetChild(1).transform.localPosition = new Vector3(0, 0, Mathf.Lerp(-0.148f, 0.0026f, 0.000000000001f + Count));
            //Count += 0.00001f;
            StartCoroutine(SetTrap());
        }
        else
        {
            //   transform.GetChild(1).transform.Translate(transform.GetChild(1).transform.position.x , transform.GetChild(1).transform.position.y, 0.148f);
           // transform.GetChild(1).transform.localPosition = new Vector3(0, 0, Mathf.Lerp(0.0026f, -0.014f, 0.0001f + Count));
          //  transform.GetChild(1).transform.localPosition = new Vector3(0, 0, -0.014f);
            Count += 0.00001f;


        }
        //  Bounders();
    }

    IEnumerator SetTrap()
    {
        yield return new WaitForSeconds(0.1f);
        transform.GetChild(1).transform.localPosition = new Vector3(0, 0, Mathf.Lerp(-0.148f, 0.0026f, 0.1f + Count));
        Count += 0.1f;
        yield return new WaitForSeconds(1f);
        Active = false;
        Count = 0;
        Count1 = 0;
        
    }

    public void Bounders()
    {
        Vector3 boundry = transform.GetChild(1).position;
        boundry.z = Mathf.Clamp(boundry.x, -0.5f, 0.0026f);
        transform.GetChild(1).position = boundry;
    }
}
