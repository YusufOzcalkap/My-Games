using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchmanager : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody rb2D;
    private float delta_Y;

    void Start()
    {
        rb2D = this.gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(40f * speed * Time.deltaTime, rb2D.velocity.y);
        Vector2 ObjectBoundaries = new Vector2(rb2D.position.x, Mathf.Clamp(rb2D.position.y, -3f, 3f));

        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 tch = touch.position;
            Vector3 TouchToWorld = Camera.main.ScreenToWorldPoint(tch);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    rb2D.MovePosition(new Vector3(rb2D.position.x, rb2D.position.y, 0f));
                    delta_Y = TouchToWorld.y - rb2D.position.y;
                    break;

                case TouchPhase.Stationary:

                    rb2D.velocity = new Vector2(40f * speed * Time.deltaTime, 0f);
                    break;

                case TouchPhase.Moved:
                    rb2D.MovePosition(new Vector3(rb2D.position.x + (speed * Time.deltaTime), TouchToWorld.y - delta_Y, 0f));
                    break;

                case TouchPhase.Ended:
                    rb2D.velocity = new Vector2(40f * speed * Time.deltaTime, 0f);
                    break;
            }
        }
    }
}
