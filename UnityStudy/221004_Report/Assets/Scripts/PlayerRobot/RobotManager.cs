using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    public GameObject RobotPrefab;
    public GameObject[] RobotPool = new GameObject[2];
    private Head[] _head = new Head[2];

    public GameObject[] RobotSpawnPosition = new GameObject[2];

    private int Select = 0;

    public bool _useSkill;

    private void Start() 
    {
        for(int i = 0; i < 2; i++)
        {
            CreateRobotInstance(i);
        }
        SelectRobot();
    }

    public void LeftAttack()
    {
        _head[Select].LeftAttack(_useSkill);
    }

    public void RightAttack()
    {
        _head[Select].RightAttack(_useSkill);
    }

    public void RobotMove(int direction)
    {
        _head[Select].MoveRobot(direction);
    }

    private void CreateRobotInstance(int num)
    {
        RobotPool[num] = Instantiate(RobotPrefab);

        RobotPool[num].name = "Robot " + (num + 1);
        RobotPool[num].transform.position = RobotSpawnPosition[num].transform.position;
        RobotPool[num].transform.rotation = RobotSpawnPosition[num].transform.rotation;
        RobotPool[num].transform.parent = gameObject.transform;

        _head[num] = RobotPool[num].GetComponentInChildren<Head>();
        _head[num].SkillNum = Random.Range(0, 3);
        RobotPool[num] = RobotPool[num].transform.GetChild(0).gameObject;
    }

    public void SelectPattern()
    {
        if(_useSkill)
        {
            _useSkill = false;
        }
        else
        {
            _useSkill = true;
        }
    }

    public void SelectRobot()
    {
        Select++;
        if(Select >= RobotPool.Length)
        {
            Select = 0;
        }
        ActivateRobot();
    }

    private void ActivateRobot()
    {
        for(int i = 0; i < RobotPool.Length; i++)
        {
            if(Select == i)
            {
                RobotPool[i].SetActive(true);
            }
            else
            {
                RobotPool[i].SetActive(false);
            }
        }
    }
}
