using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill1Sc : MonoBehaviour
{
    public GameObject FireBallPrefab;

    public Transform[] ShootPoses;

    public bool isFireBall;
    public float FireBallSpeed;

    void Start()
    {
        
    }


    void Update()
    {
        if (isFireBall)
        {
            transform.Translate(Vector3.forward * FireBallSpeed * Time.deltaTime);
        }
    }


    //Animation Event
    public void ShootFireBall()
    {
        Instantiate(FireBallPrefab, ShootPoses[0].transform.position, ShootPoses[0].rotation);
        Instantiate(FireBallPrefab, ShootPoses[1].transform.position, ShootPoses[1].rotation);
        Instantiate(FireBallPrefab, ShootPoses[2].transform.position, ShootPoses[2].rotation);
        Instantiate(FireBallPrefab, ShootPoses[3].transform.position, ShootPoses[3].rotation);
        Instantiate(FireBallPrefab, ShootPoses[4].transform.position, ShootPoses[4].rotation);
        Instantiate(FireBallPrefab, ShootPoses[5].transform.position, ShootPoses[5].rotation);
        Instantiate(FireBallPrefab, ShootPoses[6].transform.position, ShootPoses[6].rotation);
        Instantiate(FireBallPrefab, ShootPoses[7].transform.position, ShootPoses[7].rotation);

    }
}
