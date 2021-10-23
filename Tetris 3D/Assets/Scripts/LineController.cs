using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public static LineController instance;

    public GameObject line;
    private float addSpace = -0.4f;
    public int currentLine = 0;
    public int que = -1;
    public float currentDestroy;
    public float destroyCount;
    public int StartCount;
    public bool moveOn;
    int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //for (int i = 0; i < StartCount; i++)
        //{
        //    AddLine();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        

        

        LineManager[] ds = GetComponentsInChildren<LineManager>();
        foreach (LineManager childcol in ds)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (childcol == this)
                {
                    if (childcol.myQue == transform.GetChild(i).GetComponent<LineManager>().myQue)
                    {
                        print("ilerle");
                        LineManager.instance.AddPositionZ();
                    }
                }
            
            }
        }
    }

    public void AddLine()
    {
       // EnemyCube.instance.Controller = false;
       GameObject myLine =Instantiate(line, new Vector3(transform.position.x, transform.position.y , transform.position.z + (currentLine * addSpace)), Quaternion.identity);
       myLine.transform.parent = transform;
        a++;
        myLine.transform.name =""+ a;

       int rnd = Random.Range(0, 3);
        if (rnd == 0)
        {
            int rnd1 = Random.Range(0, 10);
            myLine.transform.GetChild(rnd1).GetComponent<MeshRenderer>().enabled = false;
        }
        if (rnd == 1)
        {
            int rnd1 = Random.Range(0, 9);
            myLine.transform.GetChild(rnd1).GetComponent<MeshRenderer>().enabled = false;
            myLine.transform.GetChild(rnd1 + 1).GetComponent<MeshRenderer>().enabled = false;
        }
        if (rnd == 2)
        {
            int rnd1 = Random.Range(0, 10);
            int rnd2 = Random.Range(0, 10);
            myLine.transform.GetChild(rnd1).GetComponent<MeshRenderer>().enabled = false;
            myLine.transform.GetChild(rnd2).GetComponent<MeshRenderer>().enabled = false;
        }

        currentLine++;
        Invoke("SetController" ,1f);
    }

    public void AddLineDestroy()
    {
        GameObject myLine = Instantiate(line);
        myLine.transform.parent = transform;
        myLine.transform.SetAsFirstSibling();
        myLine.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        a++;
        myLine.transform.name = "" + a;


        int rnd = Random.Range(0, 3);
        if (rnd == 0)
        {
            int rnd1 = Random.Range(0, 10);
            myLine.transform.GetChild(rnd1).GetComponent<MeshRenderer>().enabled = false;
        }
        if (rnd == 1)
        {
            int rnd1 = Random.Range(0, 9);
            myLine.transform.GetChild(rnd1).GetComponent<MeshRenderer>().enabled = false;
            myLine.transform.GetChild(rnd1 + 1).GetComponent<MeshRenderer>().enabled = false;
        }
        if (rnd == 2)
        {
            int rnd1 = Random.Range(0, 10);
            int rnd2 = Random.Range(0, 10);
            myLine.transform.GetChild(rnd1).GetComponent<MeshRenderer>().enabled = false;
            myLine.transform.GetChild(rnd2).GetComponent<MeshRenderer>().enabled = false;
        }

        myLine.transform.GetChild(rnd).GetComponent<MeshRenderer>().enabled = false;
    }

    public void CheckLine()
    {
        LineManager[] rg = GetComponentsInChildren<LineManager>();
        foreach (LineManager childcol in rg)
        {
            childcol.moveOn = true;
        }
    }

    public void CheckOff()
    {
        LineManager[] rg = GetComponentsInChildren<LineManager>();
        foreach (LineManager childcol in rg)
        {
            childcol.moveOn = false;
        }
    }

    public void Count()
    {
        LineManager[] rg = GetComponentsInChildren<LineManager>();
        foreach (LineManager childcol in rg)
        {
            childcol.destroyCount--;
        }
    }

    public void CountPlus()
    {
        LineManager[] rg = GetComponentsInChildren<LineManager>();
        foreach (LineManager childcol in rg)
        {
            childcol.destroyCount++;
        }
    }

    public void SetController()
    {
        EnemyCube.instance.Controller = true;
    }


}
