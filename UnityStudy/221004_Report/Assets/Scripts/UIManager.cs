using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private enum EDirection
    {
        Back = -1,
        Front = 1
    }
    public RobotManager RobotManager;
    public GameObject[] MoveButton = new GameObject[2];

    private GraphicRaycaster gr;

    private void Start()
    {
        gr = GetComponent<GraphicRaycaster>();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            TouchButton();
        }
    }

    private void TouchButton()
    {
        PointerEventData data = new PointerEventData(null);
        data.position = Input.GetTouch(0).position;

        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(data, results);

        if (results.Count <= 0) 
        {
            return;
        }
        else
        {
            RobotMove(results[0].gameObject);
        }
    }

    private void RobotMove(GameObject Button)
    {
        if(Button == MoveButton[0])
        {
            RobotManager.RobotMove((int)EDirection.Back);
        }
        else if(Button == MoveButton[1])
        {
            RobotManager.RobotMove((int)EDirection.Front);
        }
    }
}
