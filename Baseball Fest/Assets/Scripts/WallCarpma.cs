using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallCarpma : MonoBehaviour
{
    public static WallCarpma instance;

    public int number;

    private TextMeshPro say�;

    void Start()
    {
        instance = this;
        say� = transform.GetChild(0).GetComponent<TextMeshPro>();
        say�.text = "�" + number;
    }
}
