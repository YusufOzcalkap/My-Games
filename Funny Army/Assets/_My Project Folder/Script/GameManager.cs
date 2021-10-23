using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game")]
    public float MyCoins;
    public int Level;
    [HideInInspector] public int _circleCount;
    public GameObject[] LevelEnemies;
    public List<Transform> LevelSpawners = new List<Transform>();

    [Header("GameUI")]
    public GameObject StartUI;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public TextMeshProUGUI levelText;

    public bool gameStart;
    public GameObject Enemies;
    public GameObject MyArmy;
    public GameObject MyArmySelect;
    public GameObject Grids;
    public GameObject Rubish;


    public TextMeshProUGUI CoinText;

    private float count;
    [HideInInspector] public Animator CameraAnim;
    int counterLeft;
    int counterRight;
    void Start()
    {
        if (Level == 0) Level++;
        instance = this;
        count = 0;
        CameraAnim = Camera.main.transform.parent.GetComponent<Animator>();
       Level = PlayerPrefs.GetInt("Level", Level);
    }


    void Update()
    {

        CoinText.text = MyCoins.ToString();
        levelText.text = "LEVEL " + PlayerPrefs.GetInt("Level", Level);
        // leveller arasý geçiþ
        if (PlayerPrefs.GetInt("Level", Level) == 1)
        {
            LevelEnemies[0].gameObject.SetActive(true);
            if (!gameStart) LevelSpawners[PlayerPrefs.GetInt("Level", Level) - 1].gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Level", Level) == 2)
        {
            LevelEnemies[1].gameObject.SetActive(true);
            Enemies = LevelEnemies[1].gameObject;
        //    if (!gameStart) LevelSpawners[PlayerPrefs.GetInt("Level", Level) - 2].gameObject.SetActive(false);
            if (!gameStart) LevelSpawners[PlayerPrefs.GetInt("Level", Level) - 1].gameObject.SetActive(true);

        }

        if (PlayerPrefs.GetInt("Level", Level) == 3)
        {
            LevelEnemies[2].gameObject.SetActive(true);
            Enemies = LevelEnemies[2].gameObject;
            if (!gameStart) LevelSpawners[PlayerPrefs.GetInt("Level", Level) - 1].gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Level", Level) == 4)
        {
            LevelEnemies[3].gameObject.SetActive(true);
            Enemies = LevelEnemies[3].gameObject;
            if (!gameStart) LevelSpawners[PlayerPrefs.GetInt("Level", Level) - 1].gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Level", Level) == 5)
        {
            LevelEnemies[4].gameObject.SetActive(true);
            Enemies = LevelEnemies[4].gameObject;

            if (!gameStart) LevelSpawners[PlayerPrefs.GetInt("Level", Level) - 1].gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Level", Level) == 6)
        {
            LevelEnemies[5].gameObject.SetActive(true);
            Enemies = LevelEnemies[5].gameObject;

            if (!gameStart) LevelSpawners[PlayerPrefs.GetInt("Level", Level) - 1].gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Level", Level) == 7)
        {
            LevelEnemies[6].gameObject.SetActive(true);
            Enemies = LevelEnemies[6].gameObject;

            if (!gameStart) LevelSpawners[PlayerPrefs.GetInt("Level", Level) - 1].gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Level", Level) == 8)
        {
            LevelEnemies[7].gameObject.SetActive(true);
            Enemies = LevelEnemies[7].gameObject;

            if (!gameStart) LevelSpawners[PlayerPrefs.GetInt("Level", Level) - 1].gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Level", Level) == 9)
        {
            LevelEnemies[8].gameObject.SetActive(true);
            Enemies = LevelEnemies[8].gameObject;

            if (!gameStart) LevelSpawners[PlayerPrefs.GetInt("Level", Level) - 1].gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Level", Level) == 10)
        {
            LevelEnemies[9].gameObject.SetActive(true);
            Enemies = LevelEnemies[9].gameObject;

            if (!gameStart) LevelSpawners[PlayerPrefs.GetInt("Level", Level) - 1].gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Level", Level) == 11)
        {
            LevelEnemies[10].gameObject.SetActive(true);
            Enemies = LevelEnemies[10].gameObject;

            if (!gameStart) LevelSpawners[PlayerPrefs.GetInt("Level", Level) - 1].gameObject.SetActive(true);
        }
    }
    public void StartGame()
    {
        gameStart = true;
        CameraAnim.SetBool("See", false);
        CameraAnim.SetTrigger("Game");
        MyArmy.transform.GetChild(0).transform.parent = null;
        StartUI.gameObject.SetActive(false);
        for (int i = 0; i < Grids.transform.childCount; i++) Grids.transform.GetChild(i).transform.gameObject.SetActive(false);
    }

    public void CameraCon()
    {
        count++;

        if (count % 1 == 0)
        {
            CameraAnim.SetBool("See", true);
            Spawner.instance.Warning = true;
            MyArmySelect.GetComponent<Animator>().SetBool("Up", true);
        }

        if (count%2 == 0 )
        {
            CameraAnim.SetBool("See", false);
            Spawner.instance.Warning = false;
            MyArmySelect.GetComponent<Animator>().SetBool("Up", false);
        }
    }

    public void NextLevel()
    {
        gameStart = false;
        StartUI.gameObject.SetActive(true);
        Level++;
        PlayerPrefs.SetInt("Level", Level);
        GameManager.instance.WinPanel.gameObject.SetActive(false);

        //rubish yok etme
        for (int i = 0; i < Rubish.transform.childCount; i++) Destroy(Rubish.transform.GetChild(i).gameObject);

        // benim ordumu yok etme
        ResetMyArmy();

        //Coins
        MyCoins = 150;
    }

    public void ResetMyArmy()
    {
        MyArmy.transform.GetChild(0).gameObject.SetActive(false);
        for (int i = 1; i < MyArmy.transform.childCount; i++)
        {
           Destroy(MyArmy.transform.GetChild(i).gameObject);
        }
    }
}
