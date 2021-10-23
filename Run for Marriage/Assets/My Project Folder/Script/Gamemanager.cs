using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    public float PlayerSpeed;
    public float Money;
    public float Emerald;
    public Animator GirlAnim;

    public GameObject Ring;
    float a;
    float Count;
    bool buyu;

    [Header("Game Tools")]
    public Image EmeraldCount;
    [Range(0f, 1f)]
    public float FillAmount;

    public ParticleSystem Confeti;

    [Header("Game Text")]
    public TextMeshProUGUI MoneyText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = Money.ToString();

        if (EmeraldCount.fillAmount >= 1)
        {
            Count++;
            if (Count == 1)
            {
                Confeti.Play();
                FillAmount = 1;
            }
        }

        if (EmeraldCount.fillAmount < 1)
        {
            Count = 0;
        }

        if (FillAmount < 0)
        {
            FillAmount = 0;
        }

        if (PlayerController.instance.Finish)
        {
            if (FillAmount < 0.5f)
            {
                GirlAnim.SetBool("No", true);
            }
        }

        if (Emerald < 0 )
        {
            Emerald = 0;
        }
    }
}
