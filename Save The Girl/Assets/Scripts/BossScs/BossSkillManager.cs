using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillManager : MonoBehaviour
{
    public float timer;
    public float GetSkill;
    public int SkillIndex;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        SkillTimer();


    }
    public void SkillTimer()
    {
        timer += 1 * Time.deltaTime;
        if(timer >= GetSkill)
        {
            SkillIndex = Random.Range(0, 3);
            anim.SetInteger("SkillIndex", SkillIndex);
            anim.SetTrigger("UseSkill");
            timer = 0;
        }
    }

}
