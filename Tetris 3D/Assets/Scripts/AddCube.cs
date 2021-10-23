using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCube : MonoBehaviour
{
    public static AddCube instance;

    [Header("OBJECT")]
    public GameObject player;
    //public GameObject addPlayer;

    [Header("Particle System")]
    public ParticleSystem addPs;

    private GameObject Cubes;
    private GameObject addCubes;

    private float createLocationX;
    private float createLocationY;

    int right;
    int left;

   
    void Awake()
    {
        instance = this;
        Cubes = GameObject.Find("Cubes");
        addCubes = GameObject.Find("AddCubes");
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.currentCube < 5)
        {
            if (other.gameObject.CompareTag("Right"))
            {
                Destroy(gameObject);
                GameObject add = Instantiate(player, new Vector3(other.transform.position.x, 0.4f, other.transform.position.z), Quaternion.identity);
                add.transform.parent = Cubes.transform;
                GameManager.instance.currentCube++;
                GameManager.instance.weight++;
                CreatePs(other);

                GameManager.instance.right++;

                if (GameManager.instance.right == 1)
                {
                    CubesController.instance.rightCol[0].enabled = true;
                }
                if (GameManager.instance.right == 2)
                {
                    CubesController.instance.rightCol[1].enabled = true;
                }
                if (GameManager.instance.right == 3)
                {
                    CubesController.instance.rightCol[2].enabled = true;
                }
                //bx.size = new Vector3(0.35f, 0.41f, 0.36f);
                //bx.center = new Vector3(GameManager.instance.right * 0.42f, 0.34f, 0f);
            }

            if (other.gameObject.CompareTag("Left"))
            {
                Destroy(gameObject);
                GameObject add = Instantiate(player, new Vector3(other.transform.position.x, 0.354f, other.transform.position.z), Quaternion.identity);
                add.transform.parent = Cubes.transform;
                GameManager.instance.currentCube++;
                GameManager.instance.weight++;
                CreatePs(other);
                GameManager.instance.left++;
                //BoxCollider bx = Cubes.gameObject.AddComponent<BoxCollider>();
                //bx.size = new Vector3(0.35f, 0.41f, 0.36f);
                //bx.center = new Vector3(GameManager.instance.left * -0.42f, 0.34f, 0f);

                if (GameManager.instance.left == 1)
                {
                    CubesController.instance.leftCol[0].enabled = true;
                }
                if (GameManager.instance.left == 2)
                {
                    CubesController.instance.leftCol[1].enabled = true;
                }
                if (GameManager.instance.left == 3)
                {
                    CubesController.instance.leftCol[2].enabled = true;
                }
            }

            if (other.gameObject.CompareTag("Forward"))
            {
                Destroy(gameObject);
                GameObject add = Instantiate(player, new Vector3(other.transform.position.x, 0.4f, other.transform.position.z), Quaternion.identity);
                add.transform.parent = Cubes.transform;
                GameManager.instance.currentCube++;
                CreatePs(other);
                GameManager.instance.height++;
                GameManager.instance.CurrentHeight = add;

            }

            if (other.gameObject.CompareTag("Back"))
            {
                Destroy(gameObject);
                GameObject add = Instantiate(player, new Vector3(other.transform.position.x, 0.4f, other.transform.position.z), Quaternion.identity);
                add.transform.parent = Cubes.transform;
                GameManager.instance.currentCube++;
                CreatePs(other);

            }
        }
    }

    public void CreatePs(Collider other)
    {
        ParticleSystem ps = Instantiate(addPs, new Vector3(other.transform.position.x, 0.354f, other.transform.position.z), Quaternion.identity);
        ps.transform.parent = Cubes.transform;
        Destroy(ps.gameObject, 2f);
    }
}
