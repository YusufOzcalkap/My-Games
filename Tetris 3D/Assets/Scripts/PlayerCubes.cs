using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubes : MonoBehaviour
{
    public GameObject Cubes;

    public Vector3 startPos;

    public ParticleSystem Bom;
    // Start is called before the first frame update
    void Awake()
    {
        Cubes = GameObject.Find("Cubes");
        CubesController.instance.players.Add(transform.gameObject);
        transform.parent = Cubes.transform;
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition = new Vector3(startPos.x, startPos.y, startPos.z);
        //  transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f ,transform.position.z);
        Bounders();
    }

    public void Bounders()
    {
        Vector3 boundry = transform.position;
        boundry.y = Mathf.Clamp(boundry.y, 0.3f, 0.4f);
        transform.position = boundry;
    }
}
