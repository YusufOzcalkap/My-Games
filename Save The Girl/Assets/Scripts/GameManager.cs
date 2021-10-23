using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject StartButton;
    public GameObject RestartButton;
    public GameObject FinishUI;
    public GameObject GameOverhUI;


    public GameObject arrowUI;
    public GameObject arrow3;
    public GameObject arrow4;
    public GameObject peopletwo;
    public GameObject peoplethree;

    public Animator AnimGirl;

    [Header("ChatEnemy")]
    public GameObject people1;
    public GameObject people2;
    public GameObject people3;
    public GameObject people4;
    public GameObject GirlBubble;

    int Count = 0;
    int Count2 = 0;
    public bool isStart;
    public bool isRestart;
    void Awake()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        //Vector3 fark = Camera.main.transform.position - GirlBubble.transform.position;
        //GirlBubble.transform.rotation = Quaternion.LookRotation(-fark);

        if (girl.instance.waypointindex == 2)
        {
            Count++;
            if (Count == 1)
            {
                peopletwo.SetActive(true);

                GirlBubble.SetActive(true);
                StartCoroutine(bubbleFalse());
                StartCoroutine(AnimStart());
            }
            StartCoroutine(ArrowThreeFalse());

        }

        if (girl.instance.waypointindex == 3)
        {
            Count2++;
            if (Count2 == 1)
            {
                peoplethree.SetActive(true);
            }
            StartCoroutine(ArrowFourFalse());
        }

        if (girl.instance.girlFinish == true)
        {
            FinishUI.SetActive(true);
        }

        if (girl.instance.heartFinish == true)
        {
            GameOverhUI.SetActive(true);
        }

        GameControll();

        if (isStart)
        {
          
            StartCoroutine(ArrowOneFalse());
        }

        if (girl.instance.girlFinish)
        {
            if (people1.gameObject) Destroy(people1.gameObject);
            if (people2.gameObject) Destroy(people2.gameObject);
            if (people3.gameObject) Destroy(people3.gameObject);
            if (people4.gameObject) Destroy(people4.gameObject);
            //Destroy(people1.gameObject);
            //Destroy(people2.gameObject);
            //Destroy(people3.gameObject);
        }
    }

    public void GameControll()
    {
        if(isRestart)
        {
            inGameUI.SetActive(false);
            RestartButton.SetActive(true);
        }
    }
    public void StartGame()
    {
        inGameUI.SetActive(true);
        StartButton.SetActive(false);
        isStart = true;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void NextGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator ArrowOneFalse()
    {
        yield return new WaitForSeconds(3f);

        Destroy(arrowUI);
    }

    IEnumerator ArrowThreeFalse()
    {
        yield return new WaitForSeconds(3f);

        Destroy(arrow3);
    }

    IEnumerator ArrowFourFalse()
    {
        yield return new WaitForSeconds(3f);

        Destroy(arrow4);
    }

    IEnumerator bubbleFalse()
    {
        yield return new WaitForSeconds(6f);

        GirlBubble.SetActive(false);
    }

    IEnumerator AnimStart()
    {
        AnimGirl.SetBool("Fear", true);
        girl.instance.Speed = 0;
        yield return new WaitForSeconds(6f);

        AnimGirl.SetBool("Fear", false);
        girl.instance.Speed = 1.2f;


    }

}
