using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerStat _stat;
    private Rigidbody _rigid;

    private void Start() 
    {
        _stat = GetComponent<PlayerStat>();
        _rigid = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float Speed = _stat.MoveSpeed * Time.deltaTime;

        Vector3 newVelocity = new Vector3(x * Speed, 0f, z * Speed);
        _rigid.velocity = newVelocity;
    }
}