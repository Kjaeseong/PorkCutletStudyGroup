using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    [field: SerializeField] public List<Player> Player { get; set; }
    [field: SerializeField] public float UpdateCycle { get; set; }

    public WaitForSeconds Cycle { get; private set; }




    private void Awake() 
    {
        Cycle = new WaitForSeconds(UpdateCycle);
    }

    private void CreatePlayer()
    {
        
    }

    public void PlayerDie(int PlayerIndex)
    {
        Debug.Log($"{PlayerIndex}번 플레이어 패배");
    }
}
