using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game Manager")]
    public int destroyCount;
    public int StartCount;
    public int ResetCount;
    
    [Header("Game Manager Text")]
    public TextMeshProUGUI destroyCountText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI ResetText;

    [Header("Game Scenes")]
    public GameObject NextPanel;
    public GameObject RestartPanel;

    [Header("Game")]
    public GameObject startCube;
    public int currentCube;
    public bool GameOn = true;
    public bool ResetOn = false;
    public bool FinishGame = false;

    private GameObject addCubes;
    private float createLocationX;
    private float createLocationY;
    private float createLocationX1;
    private float createLocationY1;
    private float createLocationX2;
    private float createLocationY2;
    private float createLocationX3;
    private float createLocationY3;
    public float height;
    public float weight;
    public GameObject addPlayer;
    public GameObject lineManager;
    public Slider slide;
    
    float increaseX = 0;
    float increaseY = 0;

    int count = 0;
    public int count1 = 0;
    private GameObject Cubes;
    public GameObject CurrentHeight;
    public GameObject Tick;
    public GameObject DestroyCount;
    public Animator anim;
    public Animator Tickanim;

    public int right;
    public int left;

    void Start()
    {
        addCubes = GameObject.Find("AddCubes");
        Cubes = GameObject.Find("Cubes");
        instance = this;
        CreatePlayers();
        AddPlayer();
        if (PlayerPrefs.GetInt("level") == 0)
        {
            PlayerPrefs.SetInt("level", 1);
        }
        PlayerPrefs.GetInt("level");
        SetLevel();
        LevelText.text = "LEVEL " + PlayerPrefs.GetInt("level").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (ResetOn == true)
        {
            CreatePlayers();
            Invoke("ResetCheck", 2f);
            currentCube = 0;
            ResetOn = false;
            CubesController.instance.rightCol[0].enabled = false;
            CubesController.instance.rightCol[1].enabled = false;
            CubesController.instance.rightCol[2].enabled = false;
            CubesController.instance.leftCol[0].enabled = false;
            CubesController.instance.leftCol[1].enabled = false;
            CubesController.instance.leftCol[2].enabled = false;
        }

        SetLevelSystem();

        destroyCountText.text = destroyCount.ToString();
        ResetText.text = ResetCount.ToString();
        LevelText.text = "LEVEL " + PlayerPrefs.GetInt("level").ToString();

        // Box Collider Size and Center
        if (height == 1)
        {
            Cubes.transform.GetComponent<BoxCollider>().size = new Vector3(0.35f, 0.41f, 0.76f);
            if (CurrentHeight != null)
            {
                Cubes.transform.GetComponent<BoxCollider>().center = new Vector3(CurrentHeight.transform.GetComponent<PlayerCubes>().startPos.x, 0.34f, 0.2f);

            }
        }

        if (height == 2)
        {
            Cubes.transform.GetComponent<BoxCollider>().size = new Vector3(0.35f, 0.41f, 1.17f);
            if (CurrentHeight != null)
            {
                Cubes.transform.GetComponent<BoxCollider>().center = new Vector3(CurrentHeight.transform.GetComponent<PlayerCubes>().startPos.x, 0.34f, 0.4f);

            }
        }

        if (height == 3)
        {
            Cubes.transform.GetComponent<BoxCollider>().size = new Vector3(0.35f, 0.41f, 1.6f);
            if (CurrentHeight != null)
            {
                Cubes.transform.GetComponent<BoxCollider>().center = new Vector3(CurrentHeight.transform.GetComponent<PlayerCubes>().startPos.x, 0.34f, 0.61f);

            }
        }
    }

    public void CreatePlayers()
    {
        Cubes.transform.position = new Vector3(0,0,0);
        GameObject Start =Instantiate(startCube);
        Start.transform.position = new Vector3(0, 0.1f, 0);
        Start.transform.rotation = Quaternion.Euler(0,0,0);
        CubesController.instance.count = 0;
        CubesController.instance.count2 = 0;
        Cubes.transform.GetComponent<BoxCollider>().size = new Vector3(0.35f, 0.41f, 0.36f);
        Cubes.transform.GetComponent<BoxCollider>().center = new Vector3(0f, 0.34f, 0f);

        count1++;
        if (count1 == 1)
        {
            ResetCount--;
        }
    }

    public void AddPlayer()
    {
        for (int i = 0; i < 3; i++)
        {
            //createLocationX = Random.Range(-1.8f, 1.6f);
            //createLocationY = Random.Range(0.5f, 4.5f);

            createLocationX = Random.Range(-1.8f, -0.5f);
            createLocationY = Random.Range(1.5f, 2.5f);

            createLocationX1 = Random.Range(-1.8f, -0.5f);
            createLocationY1 = Random.Range(2f, 4.5f);

            createLocationX2 = Random.Range(-0.1f, 1.6f);
            createLocationY2 = Random.Range(2.5f, 4.5f);

            createLocationX3 = Random.Range(-0.1f, 1.6f);
            createLocationY3 = Random.Range(1.5f, 2.5f);

            increaseX += 0.18f;
            increaseY += 0.18f;

            int rnd = Random.Range(1, 5);
            print(rnd);
            if (rnd == 1)
            {
                GameObject addCube = Instantiate(addPlayer, new Vector3(createLocationX + increaseX, 0.33f, createLocationY + increaseY), Quaternion.identity);
                addCube.transform.parent = addCubes.transform;
                float rotationY = Random.Range(1, 360);
                print(createLocationY + increaseY);
                addCube.transform.rotation = Quaternion.Euler(-90, rotationY, 0);
            }

            if (rnd == 2)
            {
                GameObject addCube = Instantiate(addPlayer, new Vector3(createLocationX1 + increaseX, 0.33f, createLocationY1 + increaseY), Quaternion.identity);
                addCube.transform.parent = addCubes.transform;
                float rotationY = Random.Range(1, 360);

                addCube.transform.rotation = Quaternion.Euler(-90, rotationY, 0);
            }

            if (rnd == 3)
            {
                GameObject addCube = Instantiate(addPlayer, new Vector3(createLocationX2 + increaseX, 0.33f, createLocationY2 + increaseY), Quaternion.identity);
                addCube.transform.parent = addCubes.transform;
                float rotationY = Random.Range(1, 360);

                addCube.transform.rotation = Quaternion.Euler(-90, rotationY, 0);
            }

            if (rnd == 4)
            {
                GameObject addCube = Instantiate(addPlayer, new Vector3(createLocationX3 + increaseX, 0.33f, createLocationY3 + increaseY), Quaternion.identity);
                addCube.transform.parent = addCubes.transform;
                float rotationY = Random.Range(1, 360);

                addCube.transform.rotation = Quaternion.Euler(-90, rotationY, 0);
            }


        }

        increaseX = 0;
        increaseY = 0;
    }

    public void AddDestroy()
    {
        for (int i = 0; i < addCubes.transform.childCount; i++)
        {
            Destroy(addCubes.transform.GetChild(i).gameObject);
        }
    }

    public void DestroyCubes()
    {
        for (int i = 0; i < Cubes.transform.childCount; i++)
        {
            Destroy(Cubes.transform.GetChild(i).gameObject);
        }
    }

    public void DestroyLine()
    {
        for (int i = 0; i < lineManager.transform.childCount; i++)
        {
            Destroy(lineManager.transform.GetChild(i).gameObject);
        }
    }

    public void ResetCheck()
    {
        LineManager.instance.DestroyStartAgain();
    }

    public void SetLevel()
    {
        if (PlayerPrefs.GetInt("level") == 1)
        {
            destroyCount = 4;
            StartCount = 3;
            ResetCount = 20;
            SetEnemys(StartCount);
        }

        if (PlayerPrefs.GetInt("level") == 2)
        {
            destroyCount = 3;
            StartCount = 4;
            ResetCount = 22;

            SetEnemys(StartCount);
        }

        if (PlayerPrefs.GetInt("level") == 3)
        {
            destroyCount = 4;
            StartCount = 4;
            ResetCount = 10;

            SetEnemys(StartCount);
        }

        if (PlayerPrefs.GetInt("level") == 4)
        {
            destroyCount = 4;
            StartCount = 5;
            ResetCount = 26;

            SetEnemys(StartCount);
        }

        if (PlayerPrefs.GetInt("level") == 5)
        {
            destroyCount = 6;
            StartCount = 4;
            ResetCount = 28;

            SetEnemys(StartCount);
        }

        if (PlayerPrefs.GetInt("level") == 6)
        {
            destroyCount = 4;
            StartCount = 4;
            ResetCount = 28;

            SetEnemys(StartCount);
        }

        if (PlayerPrefs.GetInt("level") == 7)
        {
            destroyCount = 7;
            StartCount = 4;
            ResetCount = 28;

            SetEnemys(StartCount);
        }

        if (PlayerPrefs.GetInt("level") == 8)
        {
            destroyCount = 8;
            StartCount = 4;
            ResetCount = 28;

            SetEnemys(StartCount);
        }

        if (PlayerPrefs.GetInt("level") == 9)
        {
            destroyCount = 9;
            StartCount = 4;
            ResetCount = 28;

            SetEnemys(StartCount);
        }

        if (PlayerPrefs.GetInt("level") == 10)
        {
            destroyCount = 10;
            StartCount = 4;
            ResetCount = 28;

            SetEnemys(StartCount);
        }

        if (PlayerPrefs.GetInt("level") > 10)
        {
            // random
            destroyCount = 10;
            StartCount = 4;
            ResetCount = 28;

            SetEnemys(StartCount);
        }
    }

    public void SetLevelSystem()
    {
        if (destroyCount <= 0)
        {
            FinishGame = true;
            TouchController.instance.speedModifier = 0;
            count++;
            if (count ==1 )
            {
                CannonController.instance.FinishBalls();
                NextPanel.SetActive(true);
                Invoke("SetNextButton", 2.8f);
            }
        }

        if (ResetCount <= 0)
        {
            FinishGame = true;
            TouchController.instance.speedModifier = 0;
            count++;
            if (count == 1)
            {
                // CannonController.instance.FinishBalls();
                SetEnemys(15);
                queue.instance.resetLocation = true;
                RestartPanel.SetActive(true);
                Invoke("SetRestartButton", 0.5f);
            }
        }
    }

    public void NextButtonLevel()
    {
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        queue.instance.resetLocation = true;
        CannonController.instance.slide.value = 0;
        SetLevel();
        NextPanel.SetActive(false);
        ResetOn = true;

        AddDestroy();
        AddPlayer();

        DestroyCubes();
        DestroyLine();
        TouchController.instance.speedModifier = 0.004f;
        for (int i = 0; i < LineController.instance.StartCount; i++)
        {
            LineController.instance.AddLine();
        }
        count = 0;
        Invoke("SetFinish", 1f);
        // oyunu tekrardan baþlatan kodlar
    }

    public void SetFinish()
    {
        FinishGame = false;
    }

    public void SetNextButton()
    {
        NextPanel.transform.GetChild(0).gameObject.SetActive(true);
        NextPanel.transform.GetChild(1).gameObject.SetActive(true);
    }
    public void SetRestartButton()
    {
        RestartPanel.transform.GetChild(0).gameObject.SetActive(true);
        RestartPanel.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void SetEnemys(int count)
    {
        for (int i = 0; i < count; i++)
        {
            LineController.instance.AddLine();
        }
    }

    public void ReStartButton()
    {
        queue.instance.resetLocation = true;
        CannonController.instance.slide.value = 0;

        SetLevel();
        NextPanel.SetActive(false);
        ResetOn = true;

        AddDestroy();
        AddPlayer();

        DestroyCubes();
        DestroyLine();
        TouchController.instance.speedModifier = 0.004f;
        for (int i = 0; i < LineController.instance.StartCount; i++)
        {
            LineController.instance.AddLine();
        }
        NextPanel.transform.GetChild(0).gameObject.SetActive(false);
        RestartPanel.transform.GetChild(0).gameObject.SetActive(false);
        RestartPanel.transform.GetChild(1).gameObject.SetActive(false);
        count = 0;
        Invoke("SetFinish", 1f);
    }

    public void ResetButton()
    {
        ResetOn = true;
        count1 = 0;
        EnemyCube.instance.PlayerDestroy();
    }
}
