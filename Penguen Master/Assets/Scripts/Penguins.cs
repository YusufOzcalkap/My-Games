using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguins : MonoBehaviour
{
    public static Penguins instance;

    public GameObject penguin;
    public Transform home;
    
    public int penguinCount;

    private float plus;
   

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.childCount != penguinCount )
        {
            if (transform.childCount > penguinCount)
            {
                int a = transform.childCount - penguinCount;

                for(int i = 0; i < a; i++)
                {
                    if (transform.childCount == penguinCount)
                    {
                        break;
                    }

                    penguinCount++;
                }
            }

            for (int i = 0; i < penguinCount; i++)
            {
                if (transform.childCount == penguinCount)
                {
                    break;
                }

                GameObject b = Instantiate(penguin);
                b.transform.GetComponent<PlayerController>().home = home;
                b.transform.parent = this.transform;
                plus += 0.001f;
                b.transform.position = new Vector3(home.transform.position.x + plus, home.transform.position.y, home.transform.position.z);
            }
        }
        
    }
}
