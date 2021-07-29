using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    private GameManager gamemanager;

    private int startBB;

    [Header("WinScreen")]
    public Text goodJobText;
    public GameObject winPanel;
    public Image star1, star2, star3;
    public Sprite shineStar, darkStar;

    [Header("GameOver")]
    public GameObject gameOverPanel;

    void Awake()
    {
        instance = this;
        gamemanager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        startBB = gamemanager.blackBullets;
    }

    public void GameOverScreen()
    {
        gameOverPanel.SetActive(true);
    }

    public void WinScreen()
    {
        winPanel.SetActive(true);

        if (gamemanager.blackBullets >= startBB)
        {
            goodJobText.text = "FANTASTIC!";
            StartCoroutine(Stars(3));
        }
        else if (gamemanager.blackBullets >= startBB - (gamemanager.blackBullets / 2))
        {
            goodJobText.text = "AWESOME!";
            StartCoroutine(Stars(2));

        }
        else if (gamemanager.blackBullets > 0)
        {
            goodJobText.text = "WELL DONE!";
            StartCoroutine(Stars(1));

        }
        else
        {
            goodJobText.text = "GOOD";
            StartCoroutine(Stars(1));

        }
    }

    private IEnumerator Stars(int shineNumber)
    {
        yield return new WaitForSeconds(0.5f);
        switch (shineNumber)
        {
            case 3:
                yield return new WaitForSeconds(.15f);
                star1.sprite = shineStar;
                yield return new WaitForSeconds(.15f);
                star2.sprite = shineStar;
                yield return new WaitForSeconds(.15f);
                star3.sprite = shineStar;
                break;

            case 2:
                yield return new WaitForSeconds(.15f);
                star1.sprite = shineStar;
                yield return new WaitForSeconds(.15f);
                star2.sprite = shineStar;
                star3.sprite = darkStar;
                break;

            case 1:
                yield return new WaitForSeconds(.15f);
                star1.sprite = shineStar;
                star2.sprite = darkStar;
                star3.sprite = darkStar;
                break;

            case 0:
                star1.sprite = darkStar;
                star2.sprite = darkStar;
                star3.sprite = darkStar;
                break;
        }
    }
}
