using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3Sc : MonoBehaviour
{
    public GameObject Flames;
    public float RotSpeed;

    void Start()
    {
        
    }


    void Update()
    {
        if(Flames.activeSelf)
        {
            Flames.transform.Rotate(0, RotSpeed * Time.deltaTime, 0);
        }
    }
    public void CloseFlame()
    {
        Flames.SetActive(false);
        //Flames.transform.rotation = Quaternion.identity;

    }
    public void OpenFlames()
    {
        Flames.SetActive(true);
        Invoke("CloseFlame", 3f);
    }
}
