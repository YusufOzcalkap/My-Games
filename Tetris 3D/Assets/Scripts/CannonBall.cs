using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public bool abc;
    public int direction;
    private int directionafter = 1;
    public int target;

    int count = 0;

    [Header("Particles")]
    public ParticleSystem FireBall;
    public ParticleSystem FireDestroy;
    // Start is called before the first frame update
    void Start()
    {
        target = Random.Range(0,6);


        if (this.target < 3)
        {
            direction = 1;
        }
        if (this.target >= 3)
        {
            direction = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (abc)
        {
            if (CannonController.instance.direction % 2 == 0)
            {
                directionafter = 1;
            }

            if (CannonController.instance.direction % 2 == 1)
            {
                directionafter = -1;
            }
        }

        GetComponent<Rigidbody>().velocity = new Vector3(CannonController.instance.fireFields[target].position.x * 2 * -1 * directionafter, 0, CannonController.instance.fireFields[target].position.z * 2f);
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Direction"))
        {
            abc = true;
            CannonController.instance.direction++;
        }

        if (collision.gameObject.CompareTag("Add"))
        {
            abc = true;
            CannonController.instance.direction++;

            count++;
            if (count >= 10)
            {
                collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            abc = true;
            CannonController.instance.direction++;

            count++;
            if (count >= 1)
            {
                collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cannon"))
        {
            count = 0;
            // child 0 ise diye ayarla
            // next to you
            other.transform.parent.transform.parent.transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue).GetComponent<MeshRenderer>().enabled = false;
            ParticleSystem explosion = Instantiate(FireDestroy, other.transform.parent.transform.parent.transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue).transform.position, Quaternion.identity);
            explosion.Play();
            Destroy(explosion.gameObject, 3f);

            if (other.transform.parent.GetComponent<EnemyCube>().myQue - 1 >= 0)
            {
                other.transform.parent.transform.parent.transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue - 1).GetComponent<MeshRenderer>().enabled = false;
                ParticleSystem explosion1 = Instantiate(FireDestroy, other.transform.parent.transform.parent.transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue - 1).transform.position, Quaternion.identity);
                explosion1.Play();
                Destroy(explosion1.gameObject, 3f);
            }

            if (other.transform.parent.GetComponent<EnemyCube>().myQue + 1 <= 9)
            {
                other.transform.parent.transform.parent.transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue + 1).GetComponent<MeshRenderer>().enabled = false;
                ParticleSystem explosion2 = Instantiate(FireDestroy, other.transform.parent.transform.parent.transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue + 1).transform.position, Quaternion.identity);
                explosion2.Play();
                Destroy(explosion2.gameObject, 3f);
            }

            //other.transform.parent.transform.parent.transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue - 1).GetComponent<MeshRenderer>().enabled = false;
            //other.transform.parent.transform.parent.transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue + 1).GetComponent<MeshRenderer>().enabled = false;

            // behind
            
            other.transform.parent.transform.parent.transform.parent.transform.GetChild(((int)other.transform.parent.transform.parent.GetComponent<LineManager>().myQue) -1).transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue).GetComponent<MeshRenderer>().enabled = false;
            ParticleSystem explosion4 = Instantiate(FireDestroy, other.transform.parent.transform.parent.transform.parent.transform.GetChild(((int)other.transform.parent.transform.parent.GetComponent<LineManager>().myQue) - 1).transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue).transform.position, Quaternion.identity);
            explosion4.Play();
            Destroy(explosion4.gameObject, 3f);

            if (other.transform.parent.GetComponent<EnemyCube>().myQue != 0 && other.transform.parent.GetComponent<EnemyCube>().myQue != 9)
            {
                other.transform.parent.transform.parent.transform.parent.transform.GetChild(((int)other.transform.parent.transform.parent.GetComponent<LineManager>().myQue) - 1).transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue + 1).GetComponent<MeshRenderer>().enabled = false;
                ParticleSystem explosion5 = Instantiate(FireDestroy, other.transform.parent.transform.parent.transform.parent.transform.GetChild(((int)other.transform.parent.transform.parent.GetComponent<LineManager>().myQue) - 1).transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue + 1).transform.position, Quaternion.identity);
                explosion5.Play();
                Destroy(explosion5.gameObject, 3f);

                other.transform.parent.transform.parent.transform.parent.transform.GetChild(((int)other.transform.parent.transform.parent.GetComponent<LineManager>().myQue) - 1).transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue - 1).GetComponent<MeshRenderer>().enabled = false;
                ParticleSystem explosion6 = Instantiate(FireDestroy, other.transform.parent.transform.parent.transform.parent.transform.GetChild(((int)other.transform.parent.transform.parent.GetComponent<LineManager>().myQue) - 1).transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue - 1).transform.position, Quaternion.identity);
                explosion6.Play();
                Destroy(explosion6.gameObject, 3f);
            }

            //other.transform.parent.transform.parent.transform.parent.transform.GetChild(((int)other.transform.parent.transform.parent.GetComponent<LineManager>().myQue) -1).transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue + 1).GetComponent<MeshRenderer>().enabled = false;
            //other.transform.parent.transform.parent.transform.parent.transform.GetChild(((int)other.transform.parent.transform.parent.GetComponent<LineManager>().myQue) -1).transform.GetChild(other.transform.parent.GetComponent<EnemyCube>().myQue - 1).GetComponent<MeshRenderer>().enabled = false;
 
            Destroy(this.gameObject);
            CannonController.instance.direction = 0;
        }
    }
}
