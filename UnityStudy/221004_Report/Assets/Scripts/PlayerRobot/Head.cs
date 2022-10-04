using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Body Body;
    public int SkillNum;


    //테스트코드. 삭제예정
    private void Update() 
    {
        

        
    }
    //테스트코드. 삭제예정

    public void LeftAttack(bool UseSkill)
    {
        Body.LeftAttack(UseSkill);
    }

    public void RightAttack(bool UseSkill)
    {
        Body.RightAttack(UseSkill);
    }

    public void MoveRobot(int direction)
    {
        Body.RobotMove(direction);
    }
}
