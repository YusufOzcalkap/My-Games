using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public static SpawnerController instance;
    public Transform[] SpawnPos;

    public GameObject _circle;
    public List<GameObject> _circleSpawners = new List<GameObject>();
    public int Count;
    void Start()
    {
        instance = this;
        Count = -1;

        for (int i = 0; i < _circle.transform.childCount; i++)
        {
            _circleSpawners.Add(_circle.transform.GetChild(i).gameObject);
        }
    }
    void Update()
    {
        if (GameManager.instance._circleCount >= 1 && _circle.transform.childCount >= 1) _circleSpawners[0].gameObject.SetActive(true);
        else if (_circle.transform.childCount >= 1) _circleSpawners[0].gameObject.SetActive(false);
        if (GameManager.instance._circleCount >= 2 && _circle.transform.childCount >= 2) _circleSpawners[1].gameObject.SetActive(true);
        else if (_circle.transform.childCount >= 2) _circleSpawners[1].gameObject.SetActive(false);
        if (GameManager.instance._circleCount >= 3 && _circle.transform.childCount >= 3) _circleSpawners[2].gameObject.SetActive(true);
        else if (_circle.transform.childCount >= 3) _circleSpawners[2].gameObject.SetActive(false);
        if (GameManager.instance._circleCount >= 4 && _circle.transform.childCount >= 4) _circleSpawners[3].gameObject.SetActive(true);
        else if (_circle.transform.childCount >= 4) _circleSpawners[3].gameObject.SetActive(false);
        if (GameManager.instance._circleCount >= 5 && _circle.transform.childCount >= 5) _circleSpawners[4].gameObject.SetActive(true);
        else if(_circle.transform.childCount >= 5) _circleSpawners[4].gameObject.SetActive(false);
        if (GameManager.instance._circleCount >= 6 && _circle.transform.childCount >= 6) _circleSpawners[5].gameObject.SetActive(true);
        else if(_circle.transform.childCount >= 6) _circleSpawners[5].gameObject.SetActive(false);
    }
}
