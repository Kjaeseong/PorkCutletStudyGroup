using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField][Range(0, 10f)] private float _moveSpeed;
    [SerializeField][Range(0, 10)] private int _attackDamage;

    //팔은 배열로 담을수 있기야 한데 ㅇㅅㅇ..안할란다
    public Arms LeftArm;
    public Arms RightArm;
    public Dari Dari;
    public bool CanAttack;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Enemy")
        {
            LeftArm.Enemy = other.GetComponent<Enemy>();
            RightArm.Enemy = other.GetComponent<Enemy>();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Enemy")
        {
            LeftArm.Enemy = null;
            RightArm.Enemy = null;
        }
    }

    public void LeftAttack(bool UseSkill)
    {
        if(CanAttack)
        {
            LeftArm.Attack(UseSkill, _attackDamage);
        }
    }

    public void RightAttack(bool UseSkill)
    {
        if(CanAttack)
        {
            RightArm.Attack(UseSkill, _attackDamage);
        }
    }

    public void RobotMove(int direction)
    {
        Dari.Moving(direction, _moveSpeed);
    }




}
