using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip death;


    void Death()
    {
        gameObject.tag = "Untagged";

        FindObjectOfType<GameManager>().CheckEnemyCount();
        SoundManager.instance.PlaySoundFX(death, 0.5f);


        foreach (Transform obj in transform)
        {
            print("Ne oldu");
            obj.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Vector2 direction = transform.position - collision.transform.position;
            if (transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale < 1)
            {
                Death();
            }

            if (direction.x > 0)
            {
                direction.x = 1;
            }
            else direction.x = -1;

            GetComponent<Rigidbody2D>().AddForce(new Vector2((direction.x < 0 ? 0.1f : -0.1f), direction.y > 0 ? .3f : -.3f), ForceMode2D.Impulse);
            print(direction);
            
        }

        if (collision.tag == "Plank" || collision.tag == "BoxPlank")
        {
            if (collision.GetComponent<Rigidbody2D>().velocity.magnitude > 1.5f)
            {
                Death();
            }
        }

        if (collision.tag == "Ground" || collision.tag == "Untagged")
        {
            if (GetComponent<Rigidbody2D>().velocity.magnitude > 2)
            {
                Death();
            }

        }
    }
}
