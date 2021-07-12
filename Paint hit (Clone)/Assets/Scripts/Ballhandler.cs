using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ballhandler : MonoBehaviour
{
    public static float rotationSpeed = 130;

    public static float rotationTime = 3;
    public static int currentCircleNo;
    private static int CircleCount;

    public static Color oneColor;
    public GameObject ball;
    public GameObject dummyBall;
    public GameObject btn;
    public GameObject levelComplete;
    public GameObject failScreen;
    public GameObject startGameScreen;
    public GameObject circleEffect;
    public GameObject completeEffect;

    private float speed = 100;

    private int ballsCount;
    private int circleNo;
    private int heartNo;

    private Color[] ChangingColors;

    private bool gameFail;

    public Image[] balls;
    public GameObject[] Hearts;

    public Text total_balls_text;
    public Text count_balls_text;

    public SpriteRenderer spr;
    public Material splashMat;

    public AudioSource completeSound;
    public AudioSource gameFailSound;

    void Start()
    {
        ResetGame();
    }

    void ResetGame()
    {
        ChangingColors = ColorScripts.colorArray;
        oneColor = ChangingColors[0];
        spr.color = oneColor;
        splashMat.color = oneColor;

        ChangeBallsCount();
        
        GameObject gameObject2 = Instantiate(Resources.Load("round" + Random.Range(1, 4))) as GameObject;
        gameObject2.transform.position = new Vector3(0, 20, 23);
        gameObject2.name = "Circle" + circleNo;

        //MakeANewCircle();

        ballsCount = LevelHand.ballsCount;

        //oneColor = ChangingColors[circleNo];
        //spr.color = oneColor;
        //splashMat.color = oneColor;

        currentCircleNo = circleNo;
        LevelHand.currentColor = oneColor;

        if (heartNo == 0)
        {
            PlayerPrefs.SetInt("hearts", 1);
        }
        heartNo = PlayerPrefs.GetInt("hearts", 1);

        for (int i = 0; i < heartNo; i++)
        {
            Hearts[i].SetActive(true);
        }

        MakeHurdles();
    
    }

    public void Heartslow()
    {
        heartNo--;
        PlayerPrefs.SetInt("hearts", heartNo);
        Hearts[heartNo].SetActive(false);
    }

    public void failGame()
    {
        gameFailSound.Play();
        gameFail = true;
        Invoke("FailScreen", 1);
        btn.SetActive(false);
        StopCircle();
    }

    void StopCircle()
    {
        GameObject gameObject = GameObject.Find("Circle" + circleNo);
        gameObject.transform.GetComponent<MonoBehaviour>().enabled = false;
        if (gameObject.GetComponent<iTween>())
        {
            gameObject.GetComponent<iTween>().enabled = false;
        }
    }

    

    void FailScreen()
    {
        failScreen.SetActive(true);
    }

    public void HitBall()
    {
        if (ballsCount <= 1)
        {
            base.Invoke("MakeANewCircle", 0.4f);
            // Disabble Button
        }

        if (ballsCount >= 0)
        {
           balls[ballsCount].enabled = false;
        }



        ballsCount--;

        GameObject gameObject = Instantiate<GameObject>(ball, new Vector3(0, 0, -8), Quaternion.identity);
        gameObject.GetComponent<MeshRenderer>().material.color = oneColor;
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    void ChangeBallsCount()
    {
        ballsCount = LevelHand.ballsCount;
        dummyBall.GetComponent<MeshRenderer>().material.color = oneColor;

        total_balls_text.text = string.Empty + LevelHand.totalCircles;
        count_balls_text.text = string.Empty + CircleCount;

        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].enabled = false;
        }

        for (int j = 0; j < ballsCount; j++)
        {
            balls[j].enabled = true;
            balls[j].color = oneColor;
        }
    }

    void MakeANewCircle()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("circle");
        GameObject gameObject = GameObject.Find("Circle" + circleNo);
        for (int i = 0; i < 24; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        gameObject.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = Ballhandler.oneColor;

        if (gameObject.GetComponent<iTween>())
        {
            gameObject.GetComponent<iTween>().enabled = false;
        }
        foreach (GameObject target in array)
        {
            iTween.MoveBy(target, iTween.Hash(new object[]
            {
                "y",
                -2.98f,
                "easetype",
                iTween.EaseType.spring,
                "time",
                0.5
            }));
        }

        this.circleNo++;
        currentCircleNo = circleNo;

        GameObject gameObject2 = Instantiate(Resources.Load("round" + Random.Range(1, 4)))as GameObject;
        gameObject2.transform.position = new Vector3(0 , 20, 23);
        gameObject2.name = "Circle" + circleNo;

        ballsCount = LevelHand.ballsCount;

        oneColor = ChangingColors[circleNo];
        spr.color = oneColor;
        splashMat.color = oneColor;
        LevelHand.currentColor = oneColor;

        MakeHurdles();
        ChangeBallsCount();
       CircleCount++;
    }

    void MakeHurdles()
    {
        if (circleNo == 1)
            FindObjectOfType<LevelHand>().MakeHurdles1();

        if (circleNo == 2)
            FindObjectOfType<LevelHand>().MakeHurdles2();

        if (circleNo == 3)
            FindObjectOfType<LevelHand>().MakeHurdles3();

        if (circleNo == 4)
            FindObjectOfType<LevelHand>().MakeHurdles4();

        if (circleNo == 5)
            FindObjectOfType<LevelHand>().MakeHurdles5();


    }
}
