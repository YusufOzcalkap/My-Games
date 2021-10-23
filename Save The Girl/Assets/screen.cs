using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screen : MonoBehaviour
{
    [ContextMenu("Screenshot")]
    // Start is called before the first frame update
    public void ScreenShot()
    {
        ScreenCapture.CaptureScreenshot("Screenshot" + System.DateTime.Now.ToString().Replace('/', '_').Replace(' ', '_').Replace(':', '_') + ".png");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ScreenShot();
            print("ss");
        }   
    }
}
