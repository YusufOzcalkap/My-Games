using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "red")
        {
            base.gameObject.GetComponent<Collider>().enabled = false;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            base.GetComponent<Rigidbody>().AddForce(Vector3.down * 50, ForceMode.Impulse);
            Destroy(base.gameObject, .5f);
            print("GameOver");
        }
        else
        {
            base.gameObject.GetComponent<Collider>().enabled = false;
            GameObject gameObject = Instantiate(Resources.Load("splash1")) as GameObject;
            gameObject.transform.parent = collision.gameObject.transform;
            Destroy(gameObject, 0.1f);
            collision.gameObject.name = "color";
            collision.gameObject.tag = "red";
            StartCoroutine(ChangeColor(collision.gameObject));
        }
    }

    IEnumerator ChangeColor(GameObject g)
    {
        yield return new WaitForSeconds(0.1f);

        g.gameObject.GetComponent<MeshRenderer>().enabled = true;
        g.gameObject.GetComponent<MeshRenderer>().material.color = Ballhandler.oneColor;
        Destroy(base.gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
