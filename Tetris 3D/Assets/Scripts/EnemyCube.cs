using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : MonoBehaviour
{
    public static EnemyCube instance;

    private GameObject Cubes;
    private GameObject Lines;

    public bool check;
    public bool check2;
    public bool check3;
    public bool Controller;

    public int myQue;
    private int Count;

    [Header("Particle Effect")]
    public ParticleSystem bornEnemy;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Cubes = GameObject.Find("Cubes");
        Lines = GameObject.Find("Lines");
        Controller = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<MeshRenderer>().enabled == true)
        {
            Count++;
            if (Count == 1)
            {
                ParticleSystem born = Instantiate(bornEnemy, transform.position, Quaternion.identity);
                Destroy(born.gameObject, 3f);
            }
        }

        if (transform.GetComponent<MeshRenderer>().enabled == true)
        {
            transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
            transform.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
       //     transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
            transform.GetComponent<BoxCollider>().enabled = true;
        }

        if (transform.parent.transform.GetComponent<LineManager>().myQue == 0)
        {
            this.Controller = false;
            this.check3 = true;
        }

        if (check && check2 && check3)
        {
            if (transform.parent.GetComponent<LineManager>().myQue != 0)
            {
             
                if (transform.parent.transform.parent.GetChild(((int)transform.parent.GetComponent<LineManager>().myQue) - 1).transform.GetChild(myQue).GetComponent<MeshRenderer>().enabled == true)
                {
                    print("1 durum");
                    GetComponent<MeshRenderer>().enabled = true;

                    LineManager[] rg = Lines.transform.GetComponentsInChildren<LineManager>();
                    foreach (LineManager childcol in rg)
                    {
                        childcol.FinishCircle = true;
                    }

                    PlayerDestroy();
                }
                else
                {
                    print("2 durum");

                    GetComponent<MeshRenderer>().enabled = true;

                    LineManager[] cg = Lines.transform.GetComponentsInChildren<LineManager>();
                    foreach (LineManager childcol in cg)
                    {
                        childcol.FinishCircle = true;
                    }

                    PlayerDestroy();
                }

         }


            check2 = false;
        }

        if (Controller && GameManager.instance.FinishGame == false)
        {
            if (transform.parent.GetComponent<LineManager>().myQue != 0)
            {
                if (transform.parent.transform.parent.GetChild(((int)transform.parent.GetComponent<LineManager>().myQue) - 1).transform.GetChild(myQue).GetComponent<MeshRenderer>().enabled == true)
                {
                    check3 = true;
                }

                if (transform.parent.transform.parent.GetChild(((int)transform.parent.GetComponent<LineManager>().myQue) - 1).transform.GetChild(myQue).GetComponent<MeshRenderer>().enabled == false)
                {
                    if (transform.parent.transform.parent.GetChild(((int)transform.parent.GetComponent<LineManager>().myQue) - 1).transform.GetChild(myQue).GetComponent<EnemyCube>().check3 == true)
                    {
                        check3 = false;
                    }
                    else
                    {
                        check3 = false;
                    }
                }
            }
            else
            {
                check3 = false;
            }
        }


        if (transform.parent.transform.GetComponent<LineManager>().count == 10 && check)
        {
            transform.parent.transform.GetComponent<LineManager>().FinisherCircleComp();
         //   transform.parent.transform.GetComponent<LineManager>().FinisherCircle();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            //  CannonController.instance.fireOn = true;
            GameManager.instance.count1 = 0;

            if (GameManager.instance.height >= 1)
            {
                if (transform.parent.transform.GetComponent<LineManager>().myQue != 0)
                {
                    if (transform.parent.transform.parent.GetChild(((int)transform.parent.GetComponent<LineManager>().myQue) - 1).transform.GetChild(myQue).GetComponent<MeshRenderer>().enabled == false)
                    {
                        print("Ýlerle1"); ;
                    }
                    else if (transform.parent.transform.parent.GetChild(((int)transform.parent.GetComponent<LineManager>().myQue) - 1).transform.GetChild(myQue).GetComponent<MeshRenderer>().enabled == true)
                    {
                        Controller = false;

                        //CannonController.instance.count++;
                        //CannonController.instance.fireOn = true;

                        queue.instance.resetLocation = false;
                        LineManager.instance.DestroyStart();
                        GameManager.instance.height = 0;
                        GameManager.instance.GameOn = false;
                        //      GetComponent<MeshRenderer>().enabled = true;

                        LineManager[] rg = Lines.transform.GetComponentsInChildren<LineManager>();
                        foreach (LineManager childcol in rg)
                        {
                            childcol.FinishCircle = true;
                        }

                        PlayerDestroy();
                        StartCoroutine(SetController());
                    }
                }

                if (transform.parent.transform.GetComponent<LineManager>().myQue == 0)
                {
                    Controller = false;

                    //CannonController.instance.count++;
                    //CannonController.instance.fireOn = true;

                    queue.instance.resetLocation = false;
                    LineManager.instance.DestroyStart();
                    GameManager.instance.height = 0;
                    GameManager.instance.GameOn = false;
                    GetComponent<MeshRenderer>().enabled = true;

                    LineManager[] rg = Lines.transform.GetComponentsInChildren<LineManager>();
                    foreach (LineManager childcol in rg)
                    {
                        childcol.FinishCircle = true;
                    }

                    PlayerDestroy();
                    StartCoroutine(SetController());
                }

            }

            if (GameManager.instance.height == 0)
            {
                if (transform.parent.transform.GetComponent<LineManager>().myQue != 0)
                {
                    if (transform.parent.transform.parent.GetChild(((int)transform.parent.GetComponent<LineManager>().myQue) - 1).transform.GetChild(myQue).GetComponent<MeshRenderer>().enabled == false)
                    {
                        print("Ýlerle2");
                    }
                    else if(transform.parent.transform.parent.GetChild(((int)transform.parent.GetComponent<LineManager>().myQue) - 1).transform.GetChild(myQue).GetComponent<MeshRenderer>().enabled == true)
                    {
                        Controller = false;
                        print("ilerle4");
                        //CannonController.instance.count++;
                        //CannonController.instance.fireOn = true;

                        queue.instance.resetLocation = false;
                        LineManager.instance.DestroyStart();
                        GameManager.instance.height = 0;
                        GameManager.instance.GameOn = false;
                        //      GetComponent<MeshRenderer>().enabled = true;

                        LineManager[] rg = Lines.transform.GetComponentsInChildren<LineManager>();
                        foreach (LineManager childcol in rg)
                        {
                            childcol.FinishCircle = true;
                        }

                        PlayerDestroy();
                        // Controller = true;
                        StartCoroutine(SetController());
                    }
                }

                if (transform.parent.transform.GetComponent<LineManager>().myQue == 0)
                {
                    Controller = false;

                    //CannonController.instance.count++;
                    //CannonController.instance.fireOn = true;

                    queue.instance.resetLocation = false;
                    LineManager.instance.DestroyStart();
                    GameManager.instance.height = 0;
                    GameManager.instance.GameOn = false;
                    GetComponent<MeshRenderer>().enabled = true;

                    LineManager[] rg = Lines.transform.GetComponentsInChildren<LineManager>();
                    foreach (LineManager childcol in rg)
                    {
                        childcol.FinishCircle = true;
                    }

                    PlayerDestroy();
                }

            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Control"))
        {
            check2 = true;

            if (myQue >= 0 && myQue != 9)
            {
                if (transform.parent.GetChild(myQue + 1).GetComponent<EnemyCube>().check3 == true && transform.parent.GetChild(myQue + 1).GetComponent<EnemyCube>().check2 == true && transform.parent.GetChild(myQue + 1).GetComponent<EnemyCube>().check == true)
                {
                    this.check3 = true;
                }
            }

            if (myQue <= 9 && myQue != 0)
            {
                if (transform.parent.GetChild(myQue - 1).GetComponent<EnemyCube>().check3 == true && transform.parent.GetChild(myQue - 1).GetComponent<EnemyCube>().check2 == true && transform.parent.GetChild(myQue - 1).GetComponent<EnemyCube>().check == true)
                {
                    this.check3 = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Control"))
        {
            check2 = false;
        }
    }

    public void PlayerDestroy()
    {
        for (int i = 0; i < Cubes.transform.childCount; i++)
        {
           
            Destroy(Cubes.transform.GetChild(i).gameObject);

            //Reset Game

            GameManager.instance.AddDestroy();
            GameManager.instance.AddPlayer();
            Cubes.transform.position = new Vector3(0, 0, 0);
            GameManager.instance.ResetOn = true;
        }
    }

    IEnumerator StartDestroy()
    {
        yield return new WaitForSeconds(2f);
        LineManager.instance.DestroyStartAgain();
    }

    IEnumerator SetController()
    {
        yield return new WaitForSeconds(1f);

        EnemyCube[] rg = Lines.transform.GetComponentsInChildren<EnemyCube>();
        foreach (EnemyCube childcol in rg)
        {
            childcol.Controller = true;
        }
    }
}
