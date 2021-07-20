using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private Text scoreText;
    public Text scoreGameOverText;

    public int score = 0;


    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        MakeSingleton();
    }

    void Start()
    {
        AddScore(0);
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
            scoreText.text = score.ToString();
            print("Kayýt");
            PlayerPrefs.SetInt("Score", score);

        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        PlayerPrefs.SetInt("Score", score);
        scoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
    }
}
