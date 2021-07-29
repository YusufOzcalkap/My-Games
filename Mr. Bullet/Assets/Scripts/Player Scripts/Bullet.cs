using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip boxHit, plankHit, groundHit, explodeHit;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            Destroy(collision.gameObject);
            SoundManager.instance.PlaySoundFX(boxHit, 0.5f);

        }

        if (collision.gameObject.tag == "Ground")
        {
            SoundManager.instance.PlaySoundFX(groundHit, 0.5f);

        }

        if (collision.gameObject.tag == "Plank")
        {
            SoundManager.instance.PlaySoundFX(plankHit, 0.5f);

        }

        if (collision.gameObject.tag == "Tnt")
        {
            SoundManager.instance.PlaySoundFX(explodeHit, 0.5f);

        }
    }
}
