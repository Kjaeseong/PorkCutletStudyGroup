using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHp;
    private int _hp;

    private EnemySpawner _spawner;

    private void Awake() 
    {
        _spawner = GetComponentInParent<EnemySpawner>();
    }

    private void OnEnable() 
    {
        _hp = _maxHp;
    }

    private void OnDisable() 
    {
        _spawner.Respawn(gameObject);
    }

    public void TakeDamage(int Damage)
    {
        _hp -= Damage;

        if(_hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
