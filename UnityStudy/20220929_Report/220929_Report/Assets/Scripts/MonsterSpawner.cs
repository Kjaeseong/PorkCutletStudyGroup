using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int EnemyPoolSize = 4;
    private GameObject[] EnemyPool;

    private void Start() 
    {
        EnemyPool = new GameObject[EnemyPoolSize];
        for(int i = 0; i < EnemyPool.Length; i++)
        {
            CreateInstance(i);
        }
    }


    




    private void CreateInstance(int num)
    {
        EnemyPool[num] = Instantiate(EnemyPrefab);
        EnemyPool[num].name = "Enemy - " + (num + 1);
        EnemyPool[num].transform.parent = gameObject.transform;
        EnemyPool[num].SetActive(false);
    }
}
