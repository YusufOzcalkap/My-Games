using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int EnemyCount = 1;

    [HideInInspector]
    public bool gameOver;

    public int blackBullets = 3;
    public int goldenBullets = 1;

    public GameObject blackBullet, goldenBullet;

    private GameObject gameOverPanel;

    void Awake()
    {
        
        FindObjectOfType<PlayerController>().ammo = blackBullets + goldenBullets;
        for (int i = 0; i < blackBullets; i++)
        {
            GameObject bbTemp = Instantiate(blackBullet);
            bbTemp.transform.SetParent(GameObject.Find("Bullets").transform);
            bbTemp.transform.localScale = new Vector3(1,1,1);
        }

        for (int i = 0; i < goldenBullets; i++)
        {
            GameObject bbTemp = Instantiate(goldenBullet);
            bbTemp.transform.SetParent(GameObject.Find("Bullets").transform);
            bbTemp.transform.localScale = new Vector3(1, 1, 1);

        }
    }

    void Update()
    {
        if (!gameOver && FindObjectOfType<PlayerController>().ammo <= 0 && EnemyCount > 0 && GameObject.FindGameObjectsWithTag("Bullet").Length <= 0)
        {
            gameOver = true;
            GameUI.instance.GameOverScreen();
        }
    }

    public void CheckBullet()
    {
        if (goldenBullets > 0)
        {
            goldenBullets--;
            GameObject.FindGameObjectWithTag("GoldenBullet").SetActive(false);
        }
        else if (blackBullets > 0)
        {
            blackBullets--;
            GameObject.FindGameObjectWithTag("BlackBullet").SetActive(false);
        }
    }

    public void CheckEnemyCount()
    {
        EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (EnemyCount <= 0)
        {
            GameUI.instance.WinScreen();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

    }
}
