using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalHealthbarSc : MonoBehaviour
{
    public Slider TotalHealthBar;

    public int EnemysinLevel;

    public float BossHealthfloat;

    public int EnemyCounter;

    public GameObject Boss;
    public ParticleSystem BossGroundEffect;
   
    void Start()
    {
        TotalHealthBar.maxValue = EnemysinLevel;
       
    }


    void Update()
    {


        TotalHealthBar.value = EnemyCounter;

        if (EnemyCounter >= EnemysinLevel)
        {
            Boss.SetActive(true);
            BossGroundEffect.gameObject.SetActive(true);
            TotalHealthBar.value = 300;
        }
    }
}
