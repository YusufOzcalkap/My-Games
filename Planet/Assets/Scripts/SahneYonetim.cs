using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneYonetim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OyunaBasla()
    {
        SceneManager.LoadScene(1);
    }

    public void OyundanCık()
    {
        Application.Quit();
    }
}
