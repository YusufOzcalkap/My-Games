using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiyotineController : MonoBehaviour
{
    bool Back;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).transform.localPosition.y >= -4 && Back == false)
        {
            StartCoroutine(SetGiyotin());
          //  transform.GetChild(0).transform.GetChild(0).transform.localScale = new Vector3(1,1,0.5f);
        }

        if (transform.GetChild(0).transform.localPosition.y <= -2)
        {
            Back = true;
         //   transform.GetChild(0).transform.GetChild(0).transform.localScale = new Vector3(1, 1, 0.5f);

        }

        if (Back)
        {
            print(Back);
            transform.GetChild(0).transform.Translate(Vector3.forward * Time.deltaTime * 0.5f);
            //transform.GetChild(0).transform.GetChild(0).transform.localScale = new Vector3(1, 1, 1f);
            //StartCoroutine(SetGiyotin());
        }

        if (transform.GetChild(0).transform.localPosition.y >= -0.4)
        {
            Back = false;
            //transform.GetChild(0).transform.GetChild(0).transform.localScale = new Vector3(1, 1, 0.5f);

        }

        if (transform.GetChild(0).transform.localPosition.y <= -1)
        {
            transform.GetChild(0).transform.GetChild(0).transform.localScale = new Vector3(1, 1, 1f);
        }

        if (transform.GetChild(0).transform.localPosition.y >= -1)
        {
            transform.GetChild(0).transform.GetChild(0).transform.localScale = new Vector3(1, 1, 0.5f);
        }
    }

    IEnumerator SetGiyotin()
    {
        yield return new WaitForSeconds(1f);
        transform.GetChild(0).transform.Translate(Vector3.back * Time.deltaTime * 2f);
    }
}
