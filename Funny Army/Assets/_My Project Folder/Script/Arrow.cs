using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject project;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAttack()
    {
        GameObject Projecttile = Instantiate(project);
        Projecttile.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        Destroy(Projecttile.gameObject, 1f);
    }
}
