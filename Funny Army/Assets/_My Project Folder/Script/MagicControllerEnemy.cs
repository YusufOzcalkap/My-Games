using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MagicControllerEnemy : MonoBehaviour
{
    public GameObject target;
    public GameObject targetenemy;
    public double coordinate;

    public Transform[] Enemy;
    public Transform tMin;

    public GameObject arrow;

    public List<Transform> bad = new List<Transform>();

    void Awake()
    {
      //  targetenemy = GameManager.instance.;

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
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.tMin.transform.position, 0.1f);
            // transform.position = Vector3.Lerp(transform.position, tMin.transform.position, 0.1f);
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
