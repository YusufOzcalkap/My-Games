using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public static TouchController instance;

    private Touch touch;
    public float speedModifier;

    public Vector3 yon;

    public Transform[] horizantals;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        speedModifier = 0.005f;
        yon = transform.forward;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(yon * Time.deltaTime * Gamemanager.instance.PlayerSpeed);



        if (Input.touchCount > 0 && PlayerController.instance.Move)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                if (PlayerController.instance.rotation == 0)
                {
                    transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y,
                    transform.position.z);
                    BoundersX();
                }

                if (PlayerController.instance.rotation == 90)
                {
                    transform.position = new Vector3(
                   transform.position.x,
                   transform.position.y,
                   transform.position.z + +touch.deltaPosition.x * -speedModifier);

                    BoundersZ();
                }
            }
        }
    }

    public void BoundersX()
    {
        Vector3 boundry = transform.position;
        boundry.x = Mathf.Clamp(boundry.x, horizantals[index].transform.position.x - 3.3f, horizantals[index].transform.position.x + 3.3f);
        transform.position = boundry;
    }

    public void BoundersZ()
    {
        Vector3 boundry = transform.position;
        boundry.z = Mathf.Clamp(boundry.z, horizantals[index].transform.position.z - 3, horizantals[index].transform.position.z + 3);
        transform.position = boundry;
    }
}
