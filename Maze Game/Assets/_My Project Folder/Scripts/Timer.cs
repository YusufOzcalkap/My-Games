
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public TextMeshProUGUI countdownText;

    public float countdownTo;

    void Start()
    {
        instance = this;
        countdownText.text = countdownTo.ToString("#");
    }

    void Update()
    {
        if (GameManager.instance.StartGame)
        {
            countdownTo -= Time.deltaTime;

            if (countdownTo > 0)
            {
                countdownText.text = countdownTo.ToString("#");
            }
        }

       // timerText.text = DateTime.Now.ToString("hh: MM:ss");
    }

}
