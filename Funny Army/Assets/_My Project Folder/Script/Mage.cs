using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public GameObject[] projectTile;
    public GameObject project;
    // Start is called before the first frame update
    void Start()
    {
        int rnd = Random.Range(0, 14);
        project = projectTile[rnd];
        print(rnd + "random sayý");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAttack()
    {
        GameObject Projecttile = Instantiate(project);
        Projecttile.transform.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
        Destroy(Projecttile.gameObject, 5f);
    }
}
