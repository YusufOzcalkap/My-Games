using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallEksi : MonoBehaviour
{
    public static WallEksi instance;

    public int number;

    private TextMeshPro say�;

    void Start()
    {
        instance = this;
        say� = transform.GetChild(0).GetComponent<TextMeshPro>();
        say�.text = "-" + number;
    }
}
