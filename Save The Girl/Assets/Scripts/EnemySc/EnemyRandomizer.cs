using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyRandomizer : MonoBehaviour
{

    //Flags
    public int FlagIndex;
    public Image MainFlag;
    public Sprite[] Flags;

    //

    //Names
    public int NameIndex;
    public TMP_Text NameText;
    public string MainName;
    public string[] Names;
    //

    //Colors
    public int ColorIndex;
    public GameObject MainColor;
    public GameObject[] Colors;
    //
    void Start()
    {
        FlagIndex = Random.Range(0, Flags.Length);
        NameIndex = Random.Range(0, Names.Length);
        ColorIndex = Random.Range(0, Colors.Length);
        

    }


    void Update()
    {
        Randomizer();
    }

    public void Randomizer()
    {
        NameText.text = MainName;
        MainFlag.sprite = Flags[FlagIndex];
        MainName = Names[NameIndex];
        MainColor = Colors[ColorIndex];
        MainColor.SetActive(true);
    }
}
