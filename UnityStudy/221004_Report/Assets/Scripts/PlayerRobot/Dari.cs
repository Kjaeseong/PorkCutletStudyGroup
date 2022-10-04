using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dari : MonoBehaviour
{
    public GameObject Robot;


    public void Moving(int direction, float speed)
    {
        Robot.transform.Translate(0f, 0f, direction * speed * Time.deltaTime);
    }
}
