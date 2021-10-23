using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyArrowController : MonoBehaviour
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
        targetenemy = GameManager.instance.MyArmy;

        //Transform[] rg = targetenemy.transform.GetComponentsInChildren<Transform>();
        //foreach (Transform childcol in rg)
        //{
        //    bad.Add(childcol);
        //}

        //bad.Remove(bad[0]);

        bad = GameManager.instance.MyArmy.transform.Cast<Transform>().ToList();

    }

    // Update is called once per frame
    void Update()
    {
        if (tMin != null)
        {
           
            transform.position = Vector3.MoveTowards(transform.position, tMin.transform.position, 0.1f);
            transform.eulerAngles = new Vector3(-90, 0, tMin.eulerAngles.y - 180);
        }

        GetClosestEnemy(bad);

    }



    Transform GetClosestEnemy(List<Transform> enemies)
    {
        tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
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
