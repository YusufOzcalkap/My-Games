using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyLime : MonoBehaviour
{
    [SerializeField] private Transform TargetLimb;

    private ConfigurableJoint m_configurableJoint;

    Quaternion targetInýtialRotation;

    public bool mirror;

    [SerializeField] private float eulerMultuplier;
    // Start is called before the first frame update
    void Start()
    {
        this.m_configurableJoint = this.GetComponent<ConfigurableJoint>();
    //    this.targetInýtialRotation = this.TargetLimb.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //var euler = transform.eulerAngles;
        //euler.y = eulerMultuplier * euler.y;
        //transform.eulerAngles = euler;
        //CopyRotation();
        //  m_configurableJoint.targetRotation = Quaternion.Inverse(TargetLimb.rotation);

        if (!mirror)
        {
            var euler = TargetLimb.eulerAngles;
            euler.y = eulerMultuplier * euler.y;
            
            m_configurableJoint.transform.eulerAngles = euler;
        }
        //else
        //{
        //    m_configurableJoint.targetRotation = eu(TargetLimb.rotation);
        //}
    }

    private Quaternion CopyRotation()
    {
        return Quaternion.Inverse(this.TargetLimb.localRotation)* this.targetInýtialRotation;
    }
}
