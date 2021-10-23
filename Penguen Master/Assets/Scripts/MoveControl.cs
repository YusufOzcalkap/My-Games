using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public static MoveControl instance;

    private Touch touch;
    private float speedModifier;

    public float speed;
    public GameObject target;
    public GameObject target2;

    public bool hareket = true;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        speedModifier = 0.000000001f;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemySpawnSecond.instance.dur == false && EnemySpawn.instance.dur == false)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        
        if (target.transform.position.x >= 4f)
        {
            target.transform.position = new Vector3(3.9f, target.transform.position.y, target.transform.position.z);
            target2.transform.position = new Vector3(3.9f, target2.transform.position.y, target2.transform.position.z);
        }

        if (target.transform.position.x <= -4f)
        {
            target.transform.position = new Vector3(-3.9f, target.transform.position.y, target.transform.position.z);
            target2.transform.position = new Vector3(-3.9f, target2.transform.position.y, target2.transform.position.z);
        }

        if (target.transform.position.x <= 4f && target.transform.position.x >= -4f)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(
                        transform.position.x + touch.deltaPosition.x * Time.deltaTime + speedModifier,
                        transform.position.y,
                        transform.position.z);
                }
            }
        }
    }
}
