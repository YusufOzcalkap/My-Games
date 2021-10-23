using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RagdollController : MonoBehaviour
{
    [Header("My Character")]
    [SerializeField] private ConfigurableJoint myHips;
    [SerializeField] private ConfigurableJoint myLeftUpLeg;
    [SerializeField] private ConfigurableJoint myLeftLeg;
    [SerializeField] private ConfigurableJoint myRightUpLeg;
    [SerializeField] private ConfigurableJoint myRightLeg;
    [SerializeField] private ConfigurableJoint mySpine;
    [SerializeField] private ConfigurableJoint myLeftArm;
    [SerializeField] private ConfigurableJoint myLeftForeArm;
    [SerializeField] private ConfigurableJoint myHead;
    [SerializeField] private ConfigurableJoint myRightArm;
    [SerializeField] private ConfigurableJoint myRightForeArm;


    [Header("My Animation Character")]
    [SerializeField] private Transform animHips;
    [SerializeField] private Transform animLeftUpLeg;
    [SerializeField] private Transform animLeftLeg;
    [SerializeField] private Transform animRightUpLeg;
    [SerializeField] private Transform animRightLeg;
    [SerializeField] private Transform animSpine;
    [SerializeField] private Transform animLeftArm;
    [SerializeField] private Transform animLeftForeArm;
    [SerializeField] private Transform animHead;
    [SerializeField] private Transform animRightArm;
    [SerializeField] private Transform animRightForeArm;

    [Header("Ragdoll variables")]
    [SerializeField] private float eulerMultuplier;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //var euler1 = animHips.eulerAngles;
        //euler1.y = eulerMultuplier * euler1.y;
        //myHips.transform.eulerAngles = euler1;

        var euler2 = animLeftUpLeg.eulerAngles;
      //  euler2.y = eulerMultuplier * euler2.y;
        myLeftUpLeg.transform.eulerAngles = euler2;

        var euler3 = animLeftLeg.eulerAngles;
      //  euler3.y = eulerMultuplier * euler3.y;
        myLeftLeg.transform.eulerAngles = euler3;

        var euler4 = animRightUpLeg.eulerAngles;
     //   euler4.y = eulerMultuplier * euler4.y;
        myRightUpLeg.transform.eulerAngles = euler4;

        var euler5 = animRightLeg.eulerAngles;
     //   euler5.y = eulerMultuplier * euler5.y;
        myRightLeg.transform.eulerAngles = euler5;

        var euler6 = animSpine.eulerAngles;
      //  euler6.y = eulerMultuplier * euler6.y;
        mySpine.transform.eulerAngles = euler6;

        var euler7 = animLeftArm.eulerAngles;
       // euler7.y = eulerMultuplier * euler7.y;
        myLeftArm.transform.eulerAngles = euler7;

        var euler8 = animLeftForeArm.eulerAngles;
      //  euler8.y = eulerMultuplier * euler8.y;
        myLeftForeArm.transform.eulerAngles = euler8;

        var euler9 = animHead.eulerAngles;
      //  euler9.y = eulerMultuplier * euler9.y;
        myHead.transform.eulerAngles = euler9;

        var euler10 = animRightArm.eulerAngles;
      //  euler10.y = eulerMultuplier * euler10.y;
        myRightArm.transform.eulerAngles = euler10;

        var euler11 = animRightForeArm.eulerAngles;
      //  euler11.y = eulerMultuplier * euler11.y;
        myRightForeArm.transform.eulerAngles = euler11;


    }
}
