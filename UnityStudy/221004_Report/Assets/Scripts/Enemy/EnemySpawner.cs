using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float RespawnDelay = 3f;


    public void Respawn(GameObject Enemy)
    {
        StartCoroutine(EnemyRespawn(Enemy));
    } 
    
    private IEnumerator EnemyRespawn(GameObject Enemy)
    {
        yield return new WaitForSeconds(RespawnDelay);

        Enemy.SetActive(true);
    }


}
