using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    float Count;
    bool Back;

    float Count1;
    public bool Back1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).transform.localPosition.x >= -4 && Back == false)
        {
            transform.GetChild(0).transform.Translate(Vector3.right * Time.deltaTime * 3f);
        }

        if (transform.GetChild(0).transform.localPosition.x <= -4)
        {
            Back = true;
        }

        if (Back)
        {
            transform.GetChild(0).transform.Translate(Vector3.left * Time.deltaTime * 3f);
        }

        if (transform.GetChild(0).transform.localPosition.x >= 0)
        {
            Back = false;
        }

        // Second

        if (transform.GetChild(1).transform.localPosition.x <= 4 && Back1 == false)
        {
            print("Kos");
            transform.GetChild(1).transform.Translate(Vector3.left * Time.deltaTime * 3f);
        }

        if (transform.GetChild(1).transform.localPosition.x >= 4)
        {
            Back1 = true;
        }

        if (Back1)
        {
            transform.GetChild(1).transform.Translate(Vector3.right * Time.deltaTime * 3f);
        }

        if (transform.GetChild(1).transform.localPosition.x <= 0)
        {
            Back1 = false;
        }

    }
}
