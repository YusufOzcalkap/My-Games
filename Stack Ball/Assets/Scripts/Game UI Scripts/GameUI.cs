using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject homeUI, inGameUI, finishUI, gameOverUI;
    public GameObject allBtns;

    private bool btns;

    [Header("PreGame")]
    public Button soundBtn;
    public Sprite soundOnSpr, soundOffSpr;


    [Header("InGame")]
    public Image levelSlider;
    public Image currentLevelImg;
    public Image nextLevelImg;
    public Text currentLevelText, nextLevelText;

    [Header("Finish")]
    public Text finishLevelText;

    [Header("GameOver")]
    public Text gameOverScoreText;
    public Text gameOverBestText;

    private Material playerMat;
    private Player player;

    void Awake()
    {
        playerMat = FindObjectOfType<Player>().transform.GetChild(0).GetComponent<MeshRenderer>().material;
        player = FindObjectOfType<Player>();

        levelSlider.transform.parent.GetComponent<Image>().color = playerMat.color + Color.gray;
        levelSlider.color = playerMat.color;
        currentLevelImg.color = playerMat.color;
        nextLevelImg.color = playerMat.color;

        soundBtn.onClick.AddListener(() => SoundManager.instance.SoundOff());
    }

    private void Start()
    {
        currentLevelText.text = FindObjectOfType<LevelSpawner>().level.ToString();
        nextLevelText.text = FindObjectOfType<LevelSpawner>().level + 1 + "";

    }

    void Update()
    {
        if (player.playerState == Player.PlayerState.Prepare)
        {
            if (SoundManager.instance.sound && soundBtn.GetComponent<Image>().sprite != soundOnSpr)
            {
                soundBtn.GetComponent<Image>().sprite = soundOnSpr;
            }
            else if (!SoundManager.instance.sound && soundBtn.GetComponent<Image>().sprite != soundOffSpr)
            {
                soundBtn.GetComponent<Image>().sprite = soundOffSpr;
            }
        }

        if (Input.GetMouseButtonDown(0) && !IgnoreUI() && player.playerState == Player.PlayerState.Prepare)
        {
            player.playerState = Player.PlayerState.Playing;
            homeUI.SetActive(false);
            inGameUI.SetActive(true);
            finishUI.SetActive(false);
            gameOverUI.SetActive(false);
        }

        if (player.playerState == Player.PlayerState.Finish)
        {
            homeUI.SetActive(false);
            inGameUI.SetActive(false);
            finishUI.SetActive(true);
            gameOverUI.SetActive(false);

            finishLevelText.text = "Level " + FindObjectOfType<LevelSpawner>().level;
        }

        if (player.playerState == Player.PlayerState.Died)
        {
            homeUI.SetActive(false);
            inGameUI.SetActive(false);
            finishUI.SetActive(false);
            gameOverUI.SetActive(true);

            gameOverScoreText.text = ScoreManager.instance.score.ToString();
            gameOverBestText.text = PlayerPrefs.GetInt("HighScore").ToString();
            gameOverScoreText.text = PlayerPrefs.GetInt("Score").ToString();
            print(PlayerPrefs.GetInt("Score").ToString());

            if (Input.GetMouseButtonDown(0))
            {
                ScoreManager.instance.ResetScore();
                SceneManager.LoadScene(0);
            }
        }
    }

    private bool IgnoreUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultsList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultsList);

        for (int i = 0; i < raycastResultsList.Count; i++)
        {
            if (raycastResultsList[i].gameObject.GetComponent<Ignore>() != null)
            {
                raycastResultsList.RemoveAt(i);
                i--;
            }
        }

        return raycastResultsList.Count > 0;
    }

    public void LevelSliderFill(float fillAmount)
    {
        levelSlider.fillAmount = fillAmount;
    }

    public void Settings()
    {
        btns = !btns;
        allBtns.SetActive(btns);
    }
}
