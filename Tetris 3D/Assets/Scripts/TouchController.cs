using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public static TouchController instance;
    Rigidbody m_Rigidbody;
    private Touch touch;
    public float speedModifier;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        m_Rigidbody = GetComponent<Rigidbody>();
        speedModifier = 0.004f;
    }

    // Update is called once per frame
    void Update()
    {
        Bounders();

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
              //  pos = new Vector2(transform.position.x , transform.position.z);
                //   transform.position = transform.position + new Vector3(pos.x,0, pos.y + speedModifier);
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y,
                    transform.position.z + touch.deltaPosition.y * speedModifier);
                //print("yürü");
                //m_Rigidbody.MovePosition(touch.deltaPosition + new Vector2(pos.x, pos.y)* Time.deltaTime * speedModifier);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           // speedModifier = 0;
        }
    }

    public void Bounders()
    {
        Vector3 boundry = transform.position;
        boundry.x = Mathf.Clamp(boundry.x, -1.9f, 1.9f);
        boundry.z = Mathf.Clamp(boundry.z, -0.8f, 6.9f);
        transform.position = boundry;
    }
}
