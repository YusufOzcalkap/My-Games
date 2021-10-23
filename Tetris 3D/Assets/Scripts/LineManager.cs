using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public static LineManager instance;

    public int count;
    public float myQue;
    public int order;
    public float z;
    public float destroyCount;
    public bool moveOn;
    public float a;
    public int b;
    public bool FinishCircle;
    private int s = 0;
    private GameObject Lines;

    public Animator Destroyanim;
    [Header("Particle System")]
    public ParticleSystem cubeDestroy;

    void Awake()
    {
        instance = this;
        Lines = GameObject.Find("Lines");
        
        MyLine();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddPositionZ();
        }
        CheckLine(transform);

        // Eðer tamamlanýrsa
        if (count == 10 && FinishCircle)
        {
            for (int i = 0; i < 1; i++)
            {
                LineController.instance.CheckLine();
                LineController.instance.currentDestroy = myQue;
                if (LineController.instance.currentDestroy == 0) myQue++;
                StartCoroutine(SetDestroy());
                FinisherCircle();
                GameManager.instance.anim.SetTrigger("Destroy");
                GameManager.instance.Tick.SetActive(true);
                GameManager.instance.Tickanim.SetTrigger("Tick");
                StartCoroutine(SetTick());

                if (s == 0)
                {
                    LineController.instance.CountPlus();
                    LineController.instance.AddLineDestroy();
                    s++;
                }
            }
        }

        

        // Cubelerin sýralanmasý
        if (GameManager.instance.GameOn == true)
        {
            z = transform.localPosition.z;
            myQue = (z / -0.4f);
            a = (LineController.instance.currentDestroy) - myQue;

            if (LineController.instance.currentDestroy > myQue || destroyCount > 0 && LineController.instance.currentDestroy > myQue)
            {

                moveOn = false;
                for (int i = 0; i < destroyCount; i++)
                {
                    AddPositionZ();
                    myQue++;
                    //LineController.instance.moveOn = false;
                    StartCoroutine(set());
                    destroyCount--;
                }
            }
        }
    }

    public void CheckLine(Transform pTransform)
    {
        count = 0;

        foreach (Transform child in pTransform)
        {
            if (child.GetComponent<MeshRenderer>().enabled == true)
            {
                count++;
            }
        }
    }

    public void AddPositionZ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.4f);
    }

    public void ControlQue()
    {
        if (LineController.instance.currentDestroy > myQue)
        {
            AddPositionZ();
            myQue++;
        }
    }

    IEnumerator set()
    {
        yield return new WaitForSeconds(1f);
        LineController.instance.moveOn = false;
        moveOn = false;
    }

    // Line Destroy
    IEnumerator SetDestroy()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
           ParticleSystem Efect = Instantiate(cubeDestroy, transform.GetChild(i).transform.position, Quaternion.identity);
            Destroy(Efect.gameObject, 2f);
        }
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
        GameManager.instance.GameOn = true;
        queue.instance.resetLocation = true;
        CannonController.instance.fireOn = true;
        GameManager.instance.destroyCount--;
        //   CannonController.instance.count++;

    }

    public void FinisherCircle()
    {
        LineManager[] rg = Lines.transform.GetComponentsInChildren<LineManager>();
        foreach (LineManager childcol in rg)
        {
            childcol.FinishCircle = false;
        }
    }

    public void FinisherCircleComp()
    {
        LineManager[] rg = Lines.transform.GetComponentsInChildren<LineManager>();
        foreach (LineManager childcol in rg)
        {
            childcol.FinishCircle = true;
        }
    }

    public void DestroyStart()
    {
        EnemyCube[] rg = Lines.transform.GetComponentsInChildren<EnemyCube>();
        foreach (EnemyCube childcol in rg)
        {
            childcol.check = true;
        }
    }

    public void DestroyStartAgain()
    {
        EnemyCube[] rg = Lines.transform.GetComponentsInChildren<EnemyCube>();
        foreach (EnemyCube childcol in rg)
        {
            childcol.check = false;
        }
    }  

    public void MyLine()
    {
        transform.GetChild(0).GetComponent<EnemyCube>().myQue = 0;
        transform.GetChild(1).GetComponent<EnemyCube>().myQue = 1;
        transform.GetChild(2).GetComponent<EnemyCube>().myQue = 2;
        transform.GetChild(3).GetComponent<EnemyCube>().myQue = 3;
        transform.GetChild(4).GetComponent<EnemyCube>().myQue = 4;
        transform.GetChild(5).GetComponent<EnemyCube>().myQue = 5;
        transform.GetChild(6).GetComponent<EnemyCube>().myQue = 6;
        transform.GetChild(7).GetComponent<EnemyCube>().myQue = 7;
        transform.GetChild(8).GetComponent<EnemyCube>().myQue = 8;
        transform.GetChild(9).GetComponent<EnemyCube>().myQue = 9;
    }

    IEnumerator SetTick()
    {
        GameManager.instance.DestroyCount.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        GameManager.instance.Tick.SetActive(false);
        GameManager.instance.DestroyCount.SetActive(true);

    }
}
