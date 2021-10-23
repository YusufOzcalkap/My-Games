using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public static GateController instance;

    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;
    public GameObject Level5;

    public GameObject LevelStartPos2;
    public GameObject LevelStartPos3;
    public GameObject LevelStartPos4;
    public GameObject LevelStartPos5;
    void Start()
    {
        instance = this;
    }

   public void SetGateShake()
    {
        StressReceiver.instance.InduceStress(0.2f);
    }
}
