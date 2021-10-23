using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject target;
    public GameObject targetenemy;
    public double coordinate;

    public Transform[] Enemy;
    public Transform tMin;

    public GameObject arrow;

    public List<Transform> bad = new List<Transform>();
    // Start is called before the first frame update
    void Awake()
    {
        targetenemy = GameManager.instance.Enemies;

        //Transform[] rg = targetenemy.transform.GetComponentsInChildren<Transform>();
        //foreach (Transform childcol in rg)
        //{
        //    bad.Add(childcol);
        //}

        //bad.Remove(bad[0]);

        bad = GameManager.instance.Enemies.transform.Cast<Transform>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        GetClosestEnemy(bad);
        //transform.eulerAngles = new Vector3(-90, 0, tMin.eulerAngles.y - 180);
        if (tMin != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(tMin.transform.position.x, tMin.transform.position.y + 3, tMin.transform.position.z), 0.3f);
            transform.eulerAngles = new Vector3(-90, 0, tMin.eulerAngles.y - 180);
        }

        // Vector3 fark = tMin.position - tMin.transform.position;
        // Vector3 fark = new Vector3(transform.position.x, transform.position.y,transform.position.z - tMin.transform.position.z);
        //   transform.rotation = Quaternion.LookRotation(tMin.transform.position);

    }



    Transform GetClosestEnemy(List<Transform> enemies)
    {
        tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            if (t != null)
            {
                float dist = Vector3.Distance(t.position, currentPos);
                if (dist < minDist)
                {
                    tMin = t;
                    minDist = dist;
                }
            }
        }
        return tMin;
    }

    IEnumerator SEtdamage()
    {
        yield return new WaitForSeconds(2f);

        GameObject abc = Instantiate(arrow);
        abc.transform.position = new Vector3(0, 0, 0);
    }
}
