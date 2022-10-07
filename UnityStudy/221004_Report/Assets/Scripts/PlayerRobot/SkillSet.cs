using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSet : MonoBehaviour
{
    public int RefeatCount { get; private set; }
    public float CycleTime { get; private set; }
    public int AttackDamage { get; private set; }
    public bool OnRenderer { get; private set; }

    public void SelectPattern(int num)
    {
        switch(num)
        {
            case 0:
                FirstPattern();
                break;
            case 1:
                SecondPattern();
                break;
        }
    }
    private void FirstPattern()
    {
        RefeatCount = 1;
        CycleTime = 0f;
        AttackDamage = 1;
        OnRenderer = false;
    }

    private void SecondPattern()
    {
        RefeatCount = 1;
        CycleTime = 0f;
        AttackDamage = 1;
        OnRenderer = false;
    }

}
